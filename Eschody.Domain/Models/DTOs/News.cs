namespace Eschody.Domain.Models.DTOs;

public class News
{
    public int Identifier { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Developer { get; set; }
    public DateTime Date { get; set; }
    public string Version { get; set; }
}
