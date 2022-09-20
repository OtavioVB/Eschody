using Eschody.Domain.Models.ValueObjects.General;
using Eschody.Flunt.Notifications;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class Email : ValueObject
{
    private string Value { get; set; }

    public Email(string value)
    {
        Value = value;

        Assert(Assertions.EmailAssertion.CreateContract(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
