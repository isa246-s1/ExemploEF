using Microsoft.AspNetCore.Mvc;

namespace EFexemplo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Error() => View();
}