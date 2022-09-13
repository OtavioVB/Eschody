using Eschody.Domain.Models.ValueObjects.General;
using Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class PasswordNotEncrypted : ValueObject
{
    public string Value { get; private set; }

    public PasswordNotEncrypted(string value)
    {
        Value = value;

        Assert(PasswordNotEncryptedAssertion.CreateAssert(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
