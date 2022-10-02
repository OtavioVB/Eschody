using Eschody.Domain.Models.DTOs;

namespace Eschody.Domain.Conctracts.Infrascructure.Repository;

public interface IUserRepository
{
    public Task InsertNewUser(User user);
    public Task UpdateUser(User user);
    public Task DeleteUser(User user);
    public Task<User> GetUserInformation(Guid guid);
}
