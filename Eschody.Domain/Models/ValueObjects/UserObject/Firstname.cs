namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Firstname
{
    public string Value { get; private set; }

    public Firstname(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
