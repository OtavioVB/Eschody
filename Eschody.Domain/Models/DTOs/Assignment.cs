using Microsoft.AspNetCore.Identity;

namespace Eschody.Domain.Models.DTOs;

public sealed class Assignment
{
    public int Identifier { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime RequestMoment { get; set; }
    public DateTime Deadline { get; set; }
    public Guid IdentifierUser { get; set; }
}
