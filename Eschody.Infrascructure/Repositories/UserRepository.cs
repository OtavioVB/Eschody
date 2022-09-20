using Eschody.Domain.Contracts.Infrascructure.Repositories;
using Eschody.Domain.Models.DTOs;
using Eschody.Domain.Models.ValueObjects.UserObject;
using Eschody.Infrascructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eschody.Infrascructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// Método para obter modelo de usuário pelo seu identificador
    /// </summary>
    /// <param name="identifier">Identificador GUID do Usuário</param>
    /// <returns>User Class Nullable</returns>
    /// <remarks>O resultado pode ser nulo, ficar atento (realizando testes) quanto ao resultado obtido pelo handler/command</remarks>
    public async Task<User?> GetByIdAsync(Guid identifier)
    {
        var user = await _dataContext.Users.Where(p => p.Identifier == identifier).FirstOrDefaultAsync();

        if (user != null) return user;
        else return null;
    }

    /// <summary>
    /// Método para verificar se usuário existe no banco de dados pelo seu endereço de email
    /// </summary>
    /// <param name="email">Endereço de email</param>
    /// <returns>Retorno booleano</returns>
    /// <remarks>Garantir que o email seja válido para aumentar performance</remarks>
    public async Task<bool> VerifyUserExistsAsync(Email email)
    {
        var user = await _dataContext.Users.Where(p => p.Email == email.ToString()).FirstOrDefaultAsync();

        if (user != null) return true;
        else return false;
    }

    /// <summary>
    /// Método para verificar se usuário existe no banco de dados pelo seu nome de usuário
    /// </summary>
    /// <param name="username">Nome de usuário</param>
    /// <returns>Retorno booleano</returns>
    /// /// <remarks>Garantir que o username seja válido para aumento de performance</remarks>
    public async Task<bool> VerifyUserExistsAsync(Username username)
    {
        var user = await _dataContext.Users.Where(p => p.Username == username.ToString()).FirstOrDefaultAsync();

        if (user != null) return true;
        else return false;
    }
}
