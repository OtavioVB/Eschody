namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Lastname
{
    public string Value { get; private set; }

    public Lastname(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
