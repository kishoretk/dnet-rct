using System;

namespace Domain;

public class TaskItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime DateAdded { get; set; }
    public bool IsCompleted { get; set; }

}
