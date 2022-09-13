using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Infrascructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Eschody.Infrascructure.Repositories;

public class UserRepository : IBaseRepository<IdentityUser>
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task DeleteAsync(IdentityUser entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityUser?> GetByIdAsync(int id)
    {
        var user = await _dataContext.Users.FindAsync(id);
        return user;
    }

    public Task InsertAsync(IdentityUser entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(IdentityUser entity)
    {
        throw new NotImplementedException();
    }
}
