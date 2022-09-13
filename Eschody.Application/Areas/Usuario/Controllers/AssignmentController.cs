using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eschody.Application.Areas.Usuario.Controllers;

[AllowAnonymous]
[Area("Usuario")]
public class AssignmentController : Controller
{
    [Route("{area}/{controller}/{action}")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("{area}/{controller}/{action}")]
    public IActionResult Create()
    {
        return View();
    }
}
