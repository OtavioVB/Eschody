using Eschody.Domain.Models.ValueObjects;

namespace Eschody.Tests.Domain.ValueObjects;

[TestClass]
[TestCategory("Value Objects")]
public class TestEncryptedValueObject
{
    [TestMethod]
    [DataRow("**cdefghhsdfuasuhdaushdsausdhsauuhdsahusadhusdahuhudsahdsahudsa&")]
    [DataRow("abcdefghhsdfuasuhdaushdsausdhsauuhdsahusadhusdahuhudsahdsahudsa99")]
    [DataRow("abcdefghhsdfuasuhdaushdsausdhsauuhdsahusadhusdahuhudsahdsahuds")]
    [DataRow("abcdefghhsdfuasuhdaushdsausdhsauuhdsahusadhusdahuhudsahdsahudsd")]
    [DataRow("123123123123123128344328746376846387146317416874614367146731646")]
    [DataRow("")]
    public void TestInvalidPasswordEncrypted(string value)
    {
        var password = new PasswordEncrypted(value);
        Assert.IsFalse(password.IsValid);
    }

    [TestMethod]
    [DataRow("2d711642b726b04401627ca9fbac32f5c8530fb1903cc4db02258717921a4881")]
    public void TestValidPasswordEncrypted(string value)
    {
        var password = new PasswordEncrypted(value);
        Assert.IsTrue(password.IsValid);
    }
}
