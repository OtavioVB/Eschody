using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects;

public class Name : Notifiable
{
    private string Value { get; set; }

    public Name(string value)
    {
        Value = value;

        Assert(Assertions.Name.Create(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}