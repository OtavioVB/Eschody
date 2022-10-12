using Eschody.Domain.Contracts.Infrascructure.Repository;
using Eschody.Domain.Contracts.Services.Handlers;
using Eschody.Domain.Models.ENUMs;
using Eschody.Domain.Models.ValueObjects;
using Eschody.Services.Handlers.Authentication.Create;
using Eschody.Services.Handlers.Authentication.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eschody.Application.Controllers;

[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IHandler<ResponseCreateStudentAccount, RequestCreateStudentAccount> _handlerCreateStudentAccount;
    private readonly IHandler<ResponseLoginStudentAccount, RequestLoginStudentAccount> _handlerLoginStudentAccount;

    public AuthenticationController([FromServices] IHandler<ResponseCreateStudentAccount, RequestCreateStudentAccount> handlerCreateStudentAccount, [FromServices] IHandler<ResponseLoginStudentAccount, RequestLoginStudentAccount> handlerLoginStudentAccount)
    {
        _handlerLoginStudentAccount = handlerLoginStudentAccount;
        _handlerCreateStudentAccount = handlerCreateStudentAccount;
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
    public async Task<ResponseCreateStudentAccount> CreateStudentAccountAsync(
        [FromHeader][Required] string nickname,
        [FromHeader][Required] string name,
        [FromHeader][Required] string passwordNotEncrypted,
        [FromHeader][Required] string email)
    {
        var response = await _handlerCreateStudentAccount.Handle(new RequestCreateStudentAccount(new Name(name), new Email(email), new Nickname(nickname), new PasswordNotEncrypted(passwordNotEncrypted), new Role(RolesEnum.Student)));
        return response;
    }

    /// <summary>
    /// Método para logar usuário na plataforma
    /// </summary>
    /// <response code="200"><b>Ok</b> - Retorna o resultado de uma requisição válida e esperada</response>
    /// <response code="400"><b>Bad Request</b> - Retorna que a requisição é inválida</response>
    /// <response code="401"><b>Unauthorized</b> - Retorna que o usuário não está autenticado</response>
    /// <response code="403"><b>Forbidden</b> - Retorna que o usuário não tem acesso a essa região do servidor</response>
    /// <response code="404"><b>Not Found</b> - Retorna que a informação não foi possível de ser encontrada</response>
    /// <response code="500"><b>Internal Error</b> - Retorna um erro interno do servidor</response>
    [HttpGet][AllowAnonymous][Route("api/v1/[controller]/Student/Login")]
    public async Task<ResponseLoginStudentAccount> LoginStudentAccountWithUsernameAsync([FromHeader][Required] string nickname, [FromHeader][Required] string password)
    {
        return await _handlerLoginStudentAccount.Handle(new RequestLoginStudentAccount(Guid.NewGuid(), DateTime.Now, new Nickname(nickname), new PasswordNotEncrypted(password)));
    }
}