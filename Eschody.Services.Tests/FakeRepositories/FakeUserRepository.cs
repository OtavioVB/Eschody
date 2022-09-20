#pragma warning disable CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona

using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Models.DTOs;
using Eschody.Domain.Models.ValueObjects.UserObject;

namespace Eschody.Services.Tests.FakeRepositories;

public class FakeUserRepository : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid identifier)
    {
        return null;
    }

    public Task InsertNewUserInDatabase(User user)
    {
        return Task.CompletedTask;
    }

    public async Task<bool> VerifyUserExistsAsync(Email email)
    {
        return false;
    }

    public async Task<bool> VerifyUserExistsAsync(Username username)
    {
        return false;
    }
}

#pragma warning restore CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona