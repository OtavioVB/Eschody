using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Contracts.Services;
using Eschody.Domain.Models.ValueObjects.UserObject;
using Eschody.Infrascructure.Security.Cryptography;
using Eschody.Services.Handlers.Authentication.Register;
using Eschody.Services.Tests.FakeRepositories;
using Eschody.Services.Tests.FakeServices;

namespace Eschody.Services.Tests.Handlers.Register;

[TestClass]
public class TestRegisterHandler
{
    private readonly IHandler<UserRequest, UserResponse> handler;
    private readonly IHandler<UserRequest, UserResponse> handlerCryptographyError;

    public TestRegisterHandler()
    {
        handler = new UserHandlerRegister(new FakeUserRepository(), new HashEncrypter());
        handlerCryptographyError = new UserHandlerRegister(new FakeUserRepository(), new FakeHashEncrypter());
    }

    [TestMethod]
    public void TestRegularWorkflowHandler()
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
        Assert.AreEqual(200, response.Result.Code);
    }

    [TestMethod]
    public void TestPasswordNotEncryptedHandler()
    {
        var response = handlerCryptographyError.Handle(
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

        Assert.AreEqual(500, response.Result.Code);
    }
}
