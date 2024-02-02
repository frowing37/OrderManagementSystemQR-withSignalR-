using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using SignalR_Business.Abstract;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
public class MenuTableController : Controller
{
    public MenuTableController(IMenuTableService menuTableService)
    {
        _menuTableService = menuTableService;
    }

    private readonly IMenuTableService _menuTableService;
    
    [HttpGet("MenuTableCount")]
    public IActionResult MenuTableCount()
    {
        var value = _menuTableService.getMenuTableCountwS();

        return Ok(value);
    }
}