using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Eschody.Infrascructure.Repositories;

public class UserRepository : IBaseRepository<IdentityUser>
{
    public Task DeleteAsync(IdentityUser entity)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityUser?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
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
