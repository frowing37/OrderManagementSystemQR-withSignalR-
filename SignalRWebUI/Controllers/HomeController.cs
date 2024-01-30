using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Models;

namespace SignalRWebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult noContent()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Error(string errorString)
    {
        ViewBag.Error = errorString;

        return View();
    }
}

