using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects;

public class PasswordEncrypted : Notifiable
{
    private string Value { get; set; }

    public PasswordEncrypted(string value)
    {
        Value = value;

        Assert(Assertions.PasswordEncrypted.Create(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}