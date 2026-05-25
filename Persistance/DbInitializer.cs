using System;
using Domain;

namespace Persistance;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if (context.TaskItems.Any()) return;

        var taskItems = new List<TaskItem>
        {
            new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Finish project proposal",
                Description = "Complete and submit the final draft of the client project proposal.",
                DateAdded = DateTime.UtcNow.AddDays(-10),
                IsCompleted = true
            },
            new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Buy groceries",
                Description = "Purchase milk, eggs, bread, vegetables, and fruit for the week.",
                DateAdded = DateTime.UtcNow.AddDays(-7),
                IsCompleted = false
            },
            new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Book dentist appointment",
                Description = "Schedule a routine dental check-up for next month.",
                DateAdded = DateTime.UtcNow.AddDays(-5),
                IsCompleted = false
            },
            new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Read Clean Code",
                Description = "Read chapters 4 through 6 of the Clean Code book.",
                DateAdded = DateTime.UtcNow.AddDays(-3),
                IsCompleted = true
            },
            new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Workout session",
                Description = "Complete a 45-minute strength training workout.",
                DateAdded = DateTime.UtcNow.AddDays(-2),
                IsCompleted = false
            },
            new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Prepare presentation",
                Description = "Create slides for the upcoming sprint review meeting.",
                DateAdded = DateTime.UtcNow.AddHours(-12),
                IsCompleted = false
            }
        };


        await context.TaskItems.AddRangeAsync(taskItems);
        await context.SaveChangesAsync();
    }
}
