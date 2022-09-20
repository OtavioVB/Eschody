using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Contracts.Services;
using Eschody.Domain.Models.ValueObjects.UserObject;
using Eschody.Infrascructure.Security.Cryptography;
using Eschody.Services.Handlers.Authentication.Register;
using Eschody.Services.Tests.FakeRepositories;

namespace Eschody.Services.Tests.Handlers.Register;

[TestClass]
public class TestRegisterHandler
{
    private readonly IHandler<UserRequest, UserResponse> handler;

    public TestRegisterHandler()
    {
        handler = new UserHandlerRegister(new FakeUserRepository(), new HashEncrypter());
    }

    [TestMethod]
    public void TestValidExpressionRequest()
    {
        var response = handler.Handle(
            new UserRequest(
                Guid.NewGuid(), 
                DateTime.Now, 
                new Email("valid@email.com"),
                new Username("validtest"), 
                new PasswordNotEncrypted("Xx45%$#@ç"),
                new PasswordNotEncrypted("Xx45%$#@ç"),
                new Fullname("Nome testes")
            )
        );


        foreach(var notification in response.Result.Notifications)
        {
            Console.WriteLine(notification.Message);
        }
        Assert.AreEqual(200, response.Result.Code);
    }
}
