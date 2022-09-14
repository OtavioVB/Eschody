using Eschody.Domain.Models.ValueObjects.General;
using Eschody.Domain.Models.ValueObjects.UserObject.Assertions;
using Eschody.Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Lastname : ValueObject
{
    public string Value { get; private set; }

    public Lastname(string value)
    {
        Value = value;

        Assert(LastnameAssertion.CreateLastnameAssertion(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
