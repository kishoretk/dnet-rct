using Microsoft.EntityFrameworkCore;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<Application.Activities.Queries.GetActivityList.Handler>());
builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Application.Core.MappingProfiles).Assembly));

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000", "https://localhost:3000"));


app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();
        await DbInitializer.SeedData(context);
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during migration");
    }
}

app.Run();
