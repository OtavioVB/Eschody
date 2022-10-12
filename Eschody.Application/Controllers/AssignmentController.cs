using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eschody.Application.Controllers;

[ApiController]
public class AssignmentController : Controller
{
    /// <summary>
    /// Método para obter todas as tarefas criadas pelo usuário
    /// </summary>
    /// <param name="identifier">Identificador do Usuário</param>
    /// <response code="200"><b>Ok</b> - Retorna o resultado de uma requisição válida e esperada</response>
    /// <response code="400"><b>Bad Request</b> - Retorna que a requisição é inválida</response>
    /// <response code="401"><b>Unauthorized</b> - Retorna que o usuário não está autenticado</response>
    /// <response code="403"><b>Forbidden</b> - Retorna que o usuário não tem acesso a essa região do servidor</response>
    /// <response code="404"><b>Not Found</b> - Retorna que a informação não foi possível de ser encontrada</response>
    /// <response code="500"><b>Internal Error</b> - Retorna um erro interno do servidor</response>
    [HttpGet][Authorize(Roles = "Student")][Route("api/v1/[controller]/Student/GetAssignments/{identifier}")]
    public IActionResult GetAssignments([FromRoute] Guid identifier)
    {
        return StatusCode(200);
    }
}
