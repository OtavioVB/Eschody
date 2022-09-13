namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class PasswordNotEncrypted
{
    public string Value { get; private set; }

    public PasswordNotEncrypted(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
