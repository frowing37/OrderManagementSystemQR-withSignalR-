using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.BasketDto;

namespace SignalRWebUI.Controllers;

public class BasketController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BasketController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost/api/Basket/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultBasketDto>>(json);

            return View(value);
        }
        
        return View();
    }
}