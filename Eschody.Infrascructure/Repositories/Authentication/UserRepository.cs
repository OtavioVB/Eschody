using Eschody.Domain.Conctracts.Infrascructure.Repository;
using Eschody.Domain.Models.DTOs;
using Eschody.Infrascructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Eschody.Infrascructure.Repositories.Authentication;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;
    private readonly IMemoryCache _memoryCache;

    public UserRepository(DataContext dataContext, IMemoryCache memoryCache)
    {
        _dataContext = dataContext;
        _memoryCache = memoryCache;
    }

    /// <summary>
    /// Inserir novo usuário no banco de dados pelo repositório
    /// </summary>
    public async Task InsertNewUser(User user)
    {
        await _dataContext.Users.AddAsync(user);
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    /// Obter informações do usuário pelo seu ID
    /// </summary>
    /// <param name="id">Identificador do Usuário</param>
    public async Task<User?> GetUserByIdentifierAsync(Guid id)
    {
        var user = await _memoryCache.GetOrCreate("GetUserByIdentifierAsync" + id.ToString(), entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(45);
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
            entry.SetPriority(CacheItemPriority.High);
            var user = _dataContext.Users.Where(p => p.Identifier == id).FirstOrDefaultAsync();
            return user;
        });

        return user;
    }
}
