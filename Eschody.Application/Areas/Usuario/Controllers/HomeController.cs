using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eschody.Application.Areas.Usuario.Controllers;

[AllowAnonymous]
[Area("Usuario")]
public class HomeController : Controller
{
    [Route("{area}/{controller}/{action}")]
    [Route("{area}/{controller}")]
    [Route("{area}")]
    public IActionResult Index()
    {
        return View();
    }
}
