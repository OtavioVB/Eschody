using Microsoft.AspNetCore.Mvc;
using OVB.Project.Eschody.Monolithic.WebView.Models.Auth.CreateAccount;
using OVB.Project.Eschody.Monolithic.WebView.Models.Messages;
using System.Text.Json;

namespace OVB.Project.Eschody.Monolithic.WebView.Controllers;

public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult CreateInput(CreateAccountInputModel input)
    {
            
        return RedirectToAction("Create");
    }
}
