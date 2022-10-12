using Eschody.Domain.Models.DTOs;
using Eschody.Domain.Models.ValueObjects;

namespace Eschody.Domain.Contracts.Infrascructure.Repository;

public interface IUserRepository
{
    public Task InsertNewUser(User user);
    public Task<List<User>> GetAllUsers();
    public Task<User?> GetUserAsync(Nickname nickname, PasswordEncrypted passwordEncrypted);
}
