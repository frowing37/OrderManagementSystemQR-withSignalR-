using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.BasketDto;
using SignalR_Entities.Concrete;

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

    [HttpPost]
    public async Task<IActionResult> AddBasket([FromBody] CreateBasketDto createBasketDto)
    {
        Basket basket = new Basket()
        {
            Price = createBasketDto.Price,
            Count = createBasketDto.Count,
            MenuTableID = createBasketDto.MenuTableID,
            ProductID = createBasketDto.ProductID,
            TotalPrice = createBasketDto.TotalPrice
        };
        
        _basketService.AddwS(basket);

        return Ok("Basket Eklendi");
    }
}