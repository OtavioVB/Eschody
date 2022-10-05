using Eschody.Domain.Models.ValueObjects;

namespace Eschody.Tests.Domain.ValueObjects;

[TestClass]
[TestCategory("Value Objects")]
public class TestNicknameValueObject
{
    [TestMethod]
    [DataRow("aaaa")]
    [DataRow("abcdefghijklmnopqrstuvwxyz")]
    [DataRow("")]
    [DataRow("abcde abcde")]
    [DataRow("abcde abcde")]
    [DataRow("otavio2")]
    [DataRow("invalid@*")]
    public void TestInvalidNickname(string value)
    {
        var nickname = new Nickname(value);
        Assert.IsFalse(nickname.IsValid);
    }

    [TestMethod]
    [DataRow("valid")]
    [DataRow("nicknameválido")]
    [DataRow("abcdefghijklmnopqrstuvwxy")]
    public void TestValidNickname(string value)
    {
        var nickname = new Nickname(value);
        Assert.IsFalse(nickname.IsValid);
    }
}
