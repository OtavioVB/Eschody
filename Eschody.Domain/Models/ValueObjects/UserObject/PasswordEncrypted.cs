namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class PasswordEncrypted
{
    public string Value { get; private set; }

    public PasswordEncrypted(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
