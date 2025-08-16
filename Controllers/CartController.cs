using Microsoft.AspNetCore.Mvc;

namespace shopping.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
