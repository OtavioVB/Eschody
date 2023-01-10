using Microsoft.AspNetCore.Mvc;

namespace OVB.Project.Eschody.Monolithic.WebApi.Controllers;

public class AuthenticationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
