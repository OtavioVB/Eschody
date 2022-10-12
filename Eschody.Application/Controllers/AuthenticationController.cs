using Eschody.Domain.Conctracts.Infrascructure.Repository;
using Eschody.Domain.Models.ENUMs;
using Eschody.Domain.Models.ValueObjects;
using Eschody.Services.Handlers.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eschody.Application.Controllers;

[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly HandlerCreateStudentAccount _handlerCreateStudentAccount;
    private readonly IUserRepository _userRepository;   

    public AuthenticationController([FromServices] HandlerCreateStudentAccount handlerCreateStudentAccount, [FromServices] IUserRepository userRepository)
    {
        _handlerCreateStudentAccount = handlerCreateStudentAccount;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Método para criar conta de autenticação de aluno da plataforma
    /// </summary>
    /// <param name="nickname">Nome de login do Usuário</param>
    /// <param name="name">Nome completo do Usuário</param>
    /// <param name="passwordNotEncrypted">Senha desejada pelo usuário</param>
    /// <param name="email">Email de confirmação do usuário</param>
    /// <response code="200"><b>Ok</b> - Retorna o resultado de uma requisição válida e esperada</response>
    /// <response code="400"><b>Bad Request</b> - Retorna que a requisição é inválida</response>
    /// <response code="401"><b>Unauthorized</b> - Retorna que o usuário não está autenticado</response>
    /// <response code="403"><b>Forbidden</b> - Retorna que o usuário não tem acesso a essa região do servidor</response>
    /// <response code="404"><b>Not Found</b> - Retorna que a informação não foi possível de ser encontrada</response>
    /// <response code="500"><b>Internal Error</b> - Retorna um erro interno do servidor</response>
    [HttpPost][AllowAnonymous][Route("api/v1/[controller]/Student/Create")]
    public async Task<ResponseCreateStudentAccount> CreateStudentAccount(
        [FromHeader][Required] string nickname,
        [FromHeader][Required] string name,
        [FromHeader][Required] string passwordNotEncrypted,
        [FromHeader][Required] string email)
    {
        var response = await _handlerCreateStudentAccount.Handle(new RequestCreateStudentAccount(new Name(name), new Email(email), new Nickname(nickname), new PasswordNotEncrypted(passwordNotEncrypted), new Role(RolesEnum.Student)));
        return response;
    }
}