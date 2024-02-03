using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace SignalRWebUI.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Menu()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Booking()
    {
        return View();
    }
}