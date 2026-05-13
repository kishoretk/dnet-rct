using System;

namespace Domain;

public class InfoItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public required string Description { get; set; }
}
