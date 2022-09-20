using Eschody.Domain.Models.ValueObjects.General;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Fullname : ValueObject
{
    private string Value { get; set; }

    public Fullname(string value)
    {
        Value = value;

        Assertions.FullnameAssertion.CreateContract(Value);
    }

    public override string ToString()
    {
        return Value;
    }
}
