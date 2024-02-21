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
    public async Task<IActionResult> Index()
    {
        int ID = 1002;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:7237/api/Basket/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(json); 
            List<ResultBasketDto> list = new List<ResultBasketDto>();
            List<int> temp = new List<int>();
            int count = 0;

            foreach (var basket1 in values)
            {
                foreach (var basket2 in values)
                {
                    if (basket1.ProductID == basket2.ProductID && !temp.Contains(basket1.ProductID))
                    {
                        count++;
                    }
                }

                if (count != 0 && !temp.Contains(basket1.ProductID))
                {
                    basket1.Count = count;
                    basket1.TotalPrice = basket1.Price * count;
                    list.Add(basket1);
                    temp.Add(basket1.ProductID);
                    count = 0;
                }
            }

            return View(list);
        }
        
        return View();
    }

    public async Task<IActionResult> AddBasket(CreateBasketDto createBasketDto)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Basket/", createBasketDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Customer");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    [HttpGet]
    public async Task<IActionResult> DeleteBasket(int id)
    {
        int ID = 1002;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:7237/api/Basket/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(json);
            int deleteID;
            
            foreach (var basket in values)
            {
                if (basket.ProductID == id)
                {
                    deleteID = basket.BasketID;
                    break;
                }
            }
            
            var responseMessageDelete = await client.DeleteAsync($"http://localhost:7237/api/Basket/{ID}");
            
            if (responseMessageDelete.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Basket");
            }
        }

        return RedirectToAction("Error", "Home");
    }
}