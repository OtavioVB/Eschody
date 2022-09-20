using Eschody.Domain.Models.DTOs;
using Eschody.Domain.Models.ValueObjects.UserObject;

namespace Eschody.Domain.Contracts.Infrascructure.Repositories;

public interface IUserRepository
{
    public Task<User?> GetByIdAsync(Guid identifier);
    public Task<bool> VerifyUserExistsAsync(Email email);
    public Task<bool> VerifyUserExistsAsync(Username username);
}
