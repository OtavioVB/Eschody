using Eschody.Domain.Models.ValueObjects.General;
using Eschody.Domain.Models.ValueObjects.UserObject.Assertions;
using Eschody.Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Firstname : ValueObject
{
    public string Value { get; private set; }

    public Firstname(string value)
    {
        Value = value;

        Assert(FirstnameAssertion.CreateFirstNameAssertion(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
