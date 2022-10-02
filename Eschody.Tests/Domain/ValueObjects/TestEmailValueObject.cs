using Eschody.Domain.Models.ValueObjects;
using Newtonsoft.Json.Linq;

namespace Eschody.Tests.Domain.ValueObjects;

[TestClass]
[TestCategory("Value Objects")]
public class TestEmailValueObject
{
    [TestMethod]
    [DataRow("a.com")]
    [DataRow("a@a")]
    [DataRow("testeinvalido@testeinvalido")]
    [DataRow("teste@teste.invalido@")]
    [DataRow("teste.@teste")]
    [DataRow("teste.@teste.com")]
    public void TestInvalidEmail(string value)
    {
        var email = new Email(value);
        Assert.AreEqual(false, email.IsValid);
    }

    [TestMethod]
    [DataRow("teste@teste.com")]
    [DataRow("teste@teste.com.br")]
    [DataRow("teste.com@teste.com")]
    [DataRow("teste.com@teste.com.br")]
    public void TestValidEmail(string value)
    {
        var email = new Email(value);
        Assert.AreEqual(true, email.IsValid);
    }
}
