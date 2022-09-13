using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Data;

namespace Eschody.Infrascructure.Repositories;

public class UserRepository : IBaseRepository<User>
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _dataContext.Users.FindAsync(id);
        return user;
    }

    public async Task InsertAsync(User entity)
    {
        await _dataContext.AddAsync(entity);
        await _dataContext.SaveChangesAsync();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
