using Eschody.Domain.Models.ValueObjects.General;
using Eschody.Domain.Models.ValueObjects.UserObject.Assertions;
using Eschody.Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Value = value;

        Assert(EmailAssertion.CreateEmailAssertionContract(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
