using Eschody.Domain.Conctracts.Infrascructure.Repository;
using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Data;

namespace Eschody.Infrascructure.Repositories.Authentication;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task DeleteUser(User user)
    {
        _dataContext.Users!.Remove(user);
        await _dataContext.SaveChangesAsync();
    }

    public Task<User> GetUserInformation(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task InsertNewUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}
