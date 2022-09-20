using Eschody.Domain.Models.ValueObjects.General;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Username : ValueObject
{
    private string Value { get; set; }

    public Username(string value)
    {
        Value = value;

        Assertions.UsernameAssertion.CreateContract(Value);
    }

    public override string ToString()
    {
        return Value;
    }
}
