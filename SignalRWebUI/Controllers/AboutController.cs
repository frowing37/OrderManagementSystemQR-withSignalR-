using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.AboutDto;

namespace SignalRWebUI.Controllers;

public class AboutController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public AboutController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/About");

        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);

            return View(values);
        }
        
        return RedirectToAction("Error","Home");
    }
    [HttpGet]
    public async Task<IActionResult> CreateAbout()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/About", createAboutDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "About");
        }
        
        return RedirectToAction("Error", "Home");
    }
    [HttpGet]
    public async Task<IActionResult> UpdateAbout(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/About");
        
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);

            return View(values);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage =
            await client.PutAsJsonAsync("http://localhost:7237/api/About", updateAboutDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "About");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    
    public async Task<IActionResult> DeleteAbout(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:7237/api/About/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "About");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    public async Task<IActionResult> UpdateActivate(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:7237/api/About/{ID}");
        HttpResponseMessage responseMessageAll = await client.GetAsync("http://localhost:7237/api/About");

        if(responseMessage.IsSuccessStatusCode && responseMessageAll.IsSuccessStatusCode)
        {
            var jsonAbout = await responseMessage.Content.ReadAsStringAsync();
            var jsonAboutAll = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonAbout);
            var values = JsonConvert.DeserializeObject<List<UpdateAboutDto>>(jsonAboutAll);

            if (value.Status)
            {
                value.Status = false;
                Random rnd = new Random();
                int rand = 0;
                while (value.AboutID != rand || rand == 0)
                {
                    rand = rnd.Next(0,values.Count);
                }
                values[rand].Status = true;

                await client.PutAsJsonAsync("http://localhost:7237/api/About", value);
                await client.PutAsJsonAsync("http://localhost:7237/api/About", values[rand]);

                return RedirectToAction("Index", "About");
            }
            else
            {
                value.Status = true;
                await client.PutAsJsonAsync("http://localhost:7237/api/About", value);
                foreach (var about in values)
                {
                    if (about.AboutID != value.AboutID)
                    {
                        about.Status = false;
                        await client.PutAsJsonAsync("http://localhost:7237/api/About", about);
                    }
                }

                return RedirectToAction("Index", "About");
            }
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
}