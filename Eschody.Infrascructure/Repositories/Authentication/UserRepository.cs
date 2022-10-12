using Eschody.Domain.Contracts.Infrascructure.Repository;
using Eschody.Domain.Models.DTOs;
using Eschody.Domain.Models.ValueObjects;
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

        _dataContext.Database.EnsureCreated();
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

    /// <summary>
    /// Obter a lista de todos usuários presentes no banco de dados
    /// </summary>
    public async Task<List<User>> GetAllUsers()
    {
        return await _dataContext.Users.ToListAsync();
    }

    /// <summary>
    /// Obter usuário presente no banco de dados por meio do nome de usuário e uma senha
    /// </summary>
    /// <param name="nickname">Nome de Usuário</param>
    /// <param name="passwordEncrypted">Senha Encriptada</param>
    /// <returns></returns>
    /// <remarks>Necessário que a senha esteja encriptada!</remarks>
    public async Task<User?> GetUserAsync(Nickname nickname, PasswordEncrypted passwordEncrypted)
    {
        return await _dataContext.Users.Where(p => p.Nickname == nickname.ToString() && p.Password == passwordEncrypted.ToString()).FirstOrDefaultAsync();
    }
}
