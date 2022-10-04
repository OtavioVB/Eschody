using Eschody.Domain.Conctracts.Infrascructure.Repository;
using Eschody.Domain.Models.DTOs;
using Eschody.Domain.Models.Entities;
using Eschody.Domain.Models.ENUMs;
using Eschody.Domain.Models.ValueObjects;
using Eschody.Services.Security;
using Flunt.Notifications;

namespace Eschody.Services.Handlers.Authentication;

public class HandlerCreateStudentAccount : Notifiable
{
    private readonly IUserRepository _userRepository;
    private readonly EncrypterHash _encrypterHash;

    public HandlerCreateStudentAccount(IUserRepository userRepository, EncrypterHash encrypterHash)
    {
        _userRepository = userRepository;
        _encrypterHash = encrypterHash; 
    }

    public async Task<ResponseCreateStudentAccount> Handle(RequestCreateStudentAccount request)
    {
        AppendNotifications(request);

        if (IsValid == false)
        {
            var response = new ResponseCreateStudentAccount(new StatusAPICode(StatusAPIEnum.BadRequest), new Message("Não foi possível fazer a criação da conta do usuário"), new Localization("Authentication.Student.Create.HandlerCreateStudentAccount.IsValid.Not"), Notifications);
            return response;
        }

        var userEntity = new UserEntity(Guid.NewGuid(), request.Name, request.Nickname, request.Email, new PasswordEncrypted(_encrypterHash.Encrypt(request.PasswordNotEncrypted.ToString())), request.RequestTime, request.Role);

        if (userEntity.IsValid == false)
        {
            var response = new ResponseCreateStudentAccount(new StatusAPICode(StatusAPIEnum.BadRequest), new Message("Não foi possível fazer a criação da conta do usuário"), new Localization("Authentication.Student.Create.HandlerCreateStudentAccount.UserEntity.IsValid.Not"), userEntity.Notifications);
            return response;
        }

        var userAccount = new User();

        await _userRepository.InsertNewUser(userAccount);

        throw new NotImplementedException();
    }
}
