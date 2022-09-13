using Eschody.Domain.Models.ValueObjects.General;
using Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class PasswordEncrypted : ValueObject
{
    public string Value { get; private set; }

    public PasswordEncrypted(string value)
    {
        Value = value;

        Assert(PasswordEncryptedAssertion.CreateAssert(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
