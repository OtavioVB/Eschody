using Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects;

public class PasswordNotEncrypted : Notifiable
{
    private string Value { get; set; }

    public PasswordNotEncrypted(string value)
    {
        Value = value;

        Assert(Assertions.PasswordNotEncrypted.Create(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
