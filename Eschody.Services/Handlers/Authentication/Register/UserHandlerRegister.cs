using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Contracts.Infrascructure.Security.Cryptography;
using Eschody.Domain.Contracts.Services;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication.Register;

public class UserHandler : Notifiable, IHandler<UserRequest, UserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IHashEncrypter _hashEncrypter;

    public UserHandler(IUserRepository userRepository, IHashEncrypter hashEncrypter)
    {
        _hashEncrypter = hashEncrypter;
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(UserRequest request)
    {
        AddNotifications(request.Notifications);

        if(IsValid == false)
        {
            var response = new UserResponse(400, "Os dados inseridos não coincidem com o esperado", Notifications);
            return response;
        }

        if(request.PasswordNotEncrypted.ToString() == request.PasswordNotEncryptedConfirm.ToString())
        {
            AddNotification("Confirmação de senha", "É necessário que as senhas inseridas sejam iguais.");
            var response = new UserResponse(400, "Os dados inseridos não coincidem com o esperado", Notifications);
            return response;
        }

        if (await _userRepository.VerifyUserExistsAsync(request.Email) == true)
        {
            AddNotification("Email", "Esses email já está sendo utilizado, tente novamente.");
            var response = new UserResponse(400, "Dados já utilizados", Notifications);
            return response;
        }

        if (await _userRepository.VerifyUserExistsAsync(request.Username) == true)
        {
            AddNotification("Nome de usuário", "Esses nome de usuário já está sendo utilizado, tente novamente.");
            var response = new UserResponse(400, "Dados já utilizados", Notifications);
            return response;
        }

        return new UserResponse(400, "Os dados inseridos não coincidem com o esperado", Notifications);
    }
}
