using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects;

public class Email : Notifiable
{
    private string Value { get; set; }

    public Email(string value)
    {
        Value = value;

        Assert(Assertions.Email.Create(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}