using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects;

public class Message : Notifiable
{
    private string Value { get; set; }

    public Message(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
