namespace Eschody.Domain.Models.DTOs;

public class Suggestion
{
    public int Identifier { get; set; }
    public string SuggestionDescription { get; set; }
    public Guid UserIdentifier { get; set; }
}
