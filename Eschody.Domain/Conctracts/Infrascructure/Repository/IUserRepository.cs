using Eschody.Domain.Models.DTOs;

namespace Eschody.Domain.Conctracts.Infrascructure.Repository;

public interface IUserRepository
{
    public Task InsertNewUser(User user);
    public Task<List<User>> GetAllUsers();
}
