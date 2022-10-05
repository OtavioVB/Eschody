using Eschody.Domain.Models.ValueObjects;

namespace Eschody.Tests.Domain.ValueObjects;

[TestClass]
[TestCategory("Value Objects")]
public class TestNameValueObject
{
    [TestMethod]
    [DataRow("xdsxd&''%")]
    [DataRow("test")]
    [DataRow("abcdefghijklmnopqrstuvwxyz")]
    [DataRow("testes 2")]
    [DataRow("otavio 2")]
    public void TestInvalidName(string value)
    {
        var name = new Name(value);
        Assert.IsFalse(name.IsValid);
    }

    [TestMethod]
    [DataRow("teste")]
    [DataRow("abcdefghijklmnopqrstuvwxy")]
    [DataRow("Otavio Villas Boas")]
    [DataRow("     ")]
    public void TestValidName(string value)
    {
        var name = new Name(value);
        Assert.IsTrue(name.IsValid);
    }
}
