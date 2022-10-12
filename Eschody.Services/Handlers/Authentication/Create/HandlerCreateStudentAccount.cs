using Eschody.Domain.Contracts.Infrascructure.Repository;
using Eschody.Domain.Contracts.Services.Handlers;
using Eschody.Domain.Contracts.Services.Security;
using Eschody.Domain.Models.DTOs;
using Eschody.Domain.Models.Entities;
using Eschody.Domain.Models.ENUMs;
using Eschody.Domain.Models.ValueObjects;
using Eschody.Services.Security;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Eschody.Services.Handlers.Authentication.Create;

public class HandlerCreateStudentAccount : Notifiable, IHandler<ResponseCreateStudentAccount, RequestCreateStudentAccount>
{
    private readonly IUserRepository _userRepository;
    private readonly IHashEncrypter _encrypterHash;

    public HandlerCreateStudentAccount([FromServices] IUserRepository userRepository, IHashEncrypter encrypterHash)
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

        var userAccount = new User()
        {
            Identifier = userEntity.Identifier,
            Email = userEntity.Email.ToString(),
            Name = userEntity.Name.ToString(),
            Nickname = userEntity.Nickname.ToString(),
            Password = userEntity.Password.ToString(),
            RegisteredOn = userEntity.RegisteredOn,
            Role = userEntity.Role.ToString()
        };

        await _userRepository.InsertNewUser(userAccount);

        var responseSuccess = new ResponseCreateStudentAccount(new StatusAPICode(StatusAPIEnum.Ok), new Message("Requisição realizada com sucesso!"), new Localization("\"Authentication.Student.Create.HandlerCreateStudentAccount.SendRepository.Sucess"), Notifications);
        return responseSuccess;
    }
}
