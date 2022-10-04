using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects;

public class Localization : Notifiable
{
    private string Value { get; set; }

    public Localization(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
