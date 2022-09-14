using Eschody.Domain.Models.ValueObjects.General;
using Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Username : ValueObject
{
    public string Value { get; private set; }

    public Username(string value)
    {
        Value = value;

        UsernameAssertion.CreateAssert(Value);
    }

    public override string ToString()
    {
        return Value;
    }
}
