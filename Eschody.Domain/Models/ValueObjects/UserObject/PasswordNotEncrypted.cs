using Eschody.Domain.Models.ValueObjects.General;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public class PasswordNotEncrypted : ValueObject
{
    private string Value { get; set; }

    public PasswordNotEncrypted(string value)
    {
        Value = value;

        Assert(Assertions.PasswordNotEncryptedAssertion.CreateContract(Value));
    }

    public override string ToString()
    {
        return Value;
    }
}
