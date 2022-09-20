using Eschody.Domain.Models.ValueObjects.General;
using Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class PasswordEncrypted : ValueObject
{
    private string Value { get; set; }

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
