using Microsoft.AspNetCore.Mvc;

namespace Eschody.Application.Areas.Account.Controllers;

[Area("Account")]
public class LoginController : Controller
{
    [Route("{area}/{controller}/{action}")]
    public IActionResult Index()
    {
        return View();
    }
}
