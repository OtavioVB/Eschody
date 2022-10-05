using Eschody.Domain.Models.ValueObjects;

namespace Eschody.Tests.Domain.ValueObjects;

[TestClass]
[TestCategory("Value Objects")]
public class TestNotEncryptedValueObject
{
    [TestMethod]
    [DataRow("lu*54")]
    [DataRow("luuuuu")]
    [DataRow("testes")]
    [DataRow("teste2")]
    [DataRow("abcdefghijklmnopqrstuvwxyz2lu&&")]
    [DataRow("2342334")]
    [DataRow("234234234&*")]
    public void TestInvalidPasswordNotEncrypted(string value)
    {
        var password = new PasswordNotEncrypted(value);
        Assert.IsFalse(password.IsValid);
    }

    [TestMethod]
    [DataRow("precisadeletra32432&")]
    [DataRow("123&xd")]
    [DataRow("1sd&xd")]
    [DataRow("abcdefghijklmnopqyz2lu&&")]
    [DataRow("123 xd")] // Espaço em branco conta como símbolos
    public void TestValidPasswordNotEncrypted(string value)
    {
        var password = new PasswordNotEncrypted(value);
        Assert.IsTrue(password.IsValid);
    }
}
