using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]

public class BasketController : Controller
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet("{ID}")]
    public IActionResult GetBasketByMenuTable(int ID)
    {
        var values = _basketService.getBasketByMenuTablewS(ID);

        return Ok(values);
    }
}