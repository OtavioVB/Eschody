using Eschody.Domain.Models.DTOs;

namespace Eschody.Domain.Contracts.Infrascructure.Repository;

public interface IUserRepository
{
    public Task InsertNewUser(User user);
    public Task<List<User>> GetAllUsers();
}
