namespace Eschody.Domain.Models.DTOs;

public class User
{
    public Guid Identifier { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime Created { get; set; }
}
