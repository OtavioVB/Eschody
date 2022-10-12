using Eschody.Domain.Contracts.Infrascructure.Repository;
using Eschody.Domain.Contracts.Services.Handlers;
using Eschody.Domain.Contracts.Services.Security;
using Eschody.Domain.Contracts.Services.Token;
using Eschody.Domain.Models.ValueObjects;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Login;

public class HandlerLoginStudentAccount : Notifiable, IHandler<ResponseLoginStudentAccount, RequestLoginStudentAccount>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IHashEncrypter _hashEncrypter;

    public HandlerLoginStudentAccount(IUserRepository userRepository, ITokenService tokenService, IHashEncrypter hashEncrypter)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
        _hashEncrypter = hashEncrypter;
    }

    public async Task<ResponseLoginStudentAccount> Handle(RequestLoginStudentAccount request)
    {
        if (request.IsValid == false)
        {
            var response = new ResponseLoginStudentAccount(Guid.NewGuid(), "404", "Não foi possível realizar o login", "Eschody.Services.Handlers.Authentication.Login.Handle()", Notifications);
            return response;
        }

        var passwordEncrypted = new PasswordEncrypted(_hashEncrypter.Encrypt(request.PasswordNotEncrypted.ToString()));

        if (passwordEncrypted.IsValid == false)
        {
            var response = new ResponseLoginStudentAccount(Guid.NewGuid(), "500", "Não foi possível realizar o login", "Eschody.Services.Handlers.Authentication.Login.Handle(),EncryptingPassword.Error", passwordEncrypted.Notifications);
            return response;
        }

        var user = await _userRepository.GetUserAsync(request.Nickname, passwordEncrypted);

        if (user == null)
        {
            AddNotification("Login Database", "As credenciais do usuário são incorretas, não foi possível realizar o login.");
            var response = new ResponseLoginStudentAccount(Guid.NewGuid(), "404", "Não foi possível realizar o login", "Eschody.Services.Handlers.Authentication.Login.Handle()", Notifications);
            return response;
        }

        string token = _tokenService.GenerateToken(user);

        user.Password = String.Empty;
        user.Email = String.Empty;
        var responseSuccess = new ResponseLoginStudentAccount(request.Identifier, "200", "Login realizado com sucesso!", "Eschody.Services.Handlers.Authentication.Login.Handle().Token.Success", Notifications, token, user);
        return responseSuccess;
    }
}
