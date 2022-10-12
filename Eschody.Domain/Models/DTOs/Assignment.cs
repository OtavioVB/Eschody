using System.Text.Json.Serialization;

namespace Eschody.Domain.Models.DTOs;

public class Assignment
{
    public Guid Identifier { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime Deadline { get;set; }
    public bool Done { get; set; }

    // Relationships
    [JsonIgnore] public User User { get; set; }
    
    public Assignment()
    {
        Title = String.Empty;
        User = new User();
    }
}
