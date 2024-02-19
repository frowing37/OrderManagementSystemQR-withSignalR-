using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.AboutDto;
using SignalRWebUI.Models.Dtos.DiscountDto;
using SignalRWebUI.Models.Dtos.MessageDto;

namespace SignalRWebUI.Controllers;

public class CustomerController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CustomerController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Discount");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);

            return View(values);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    
    public IActionResult Menu()
    {
        return View();
    }

    public async Task<IActionResult> About()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/About");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            List<ResultAboutDto> temp = new List<ResultAboutDto>();
            
            foreach (var value in values)
            {
                if(value.Status)
                {
                    temp.Add(value);
                }
            }

            return View(values);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    public IActionResult Booking()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Message()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Message(CreateMessageDto createMessageDto)
    {
        createMessageDto.MessageSendDate = DateTime.Now;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Message", createMessageDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Customer");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    public IActionResult Chat()
    {
        return View();
    }
}