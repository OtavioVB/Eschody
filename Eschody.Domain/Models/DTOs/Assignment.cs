using System.Text.Json.Serialization;

namespace Eschody.Domain.Models.DTOs;

public class Assignment
{
    public Guid Identifier { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime Deadline { get;set; }

    // Relationships
    [JsonIgnore] public User User { get; set; } = new User();
}
