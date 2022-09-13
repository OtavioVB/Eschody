namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Username
{
    public string Value { get; private set; }

    public Username(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
