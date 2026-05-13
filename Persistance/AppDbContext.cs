using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<InfoItem> InfoItems { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
}
