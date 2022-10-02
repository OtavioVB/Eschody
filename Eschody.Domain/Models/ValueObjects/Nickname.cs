using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects;

public class Nickname : Notifiable
{
    private string Value { get; set; }
    
    public Nickname(string value)
    {
        Value = value;

        Assert(Assertions.Nickname.Create(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
