using Eschody.Domain.Models.ValueObjects.General;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class PasswordEncrypted : ValueObject
{
    private string Value { get; set; }

    public PasswordEncrypted(string value)
    {
        Value = value;

        Assert(Assertions.PasswordEncryptedAssertion.CreateContract(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
