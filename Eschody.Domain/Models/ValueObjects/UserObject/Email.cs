namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Email
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
