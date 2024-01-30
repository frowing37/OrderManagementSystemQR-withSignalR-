using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.SocialMediaDto;

namespace SignalRWebUI.Controllers;

public class SocialMediaController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SocialMediaController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/SocialMedia");

        if(responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(json);

            return View(values);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    [HttpGet]
    public IActionResult CreateSocialMedia()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/SocialMedia", createSocialMediaDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "SocialMedia");
        }   
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateSocialMedia(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:7237/api/SocialMedia/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(json);

            return View(value);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PutAsJsonAsync("http://localhost:7237/api/SocialMedia", updateSocialMediaDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "SocialMedia");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    public async Task<IActionResult> DeleteSocialMedia(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"http://localhost:7237/api/SocialMedia/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "SocialMedia");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }


}