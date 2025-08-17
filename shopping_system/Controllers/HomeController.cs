using Microsoft.AspNetCore.Mvc;

namespace shopping.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
