using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.NotificationDto;

namespace SignalRWebUI.Controllers;

public class NotificationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NotificationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Notification/NotificationList");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(json);

            return View(values);
        }
        
        return View();
    }

    [HttpGet]
    public IActionResult CreateNotification()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Notification",createNotificationDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Notification");
        }

        return RedirectToAction("Error", "Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateNotification(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:7237/api/Notification/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateNotificationDto>(json);

            return View(value);
        }
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PutAsJsonAsync("http://localhost:7237/api/Notification",updateNotificationDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Notification");
        }
        
        return RedirectToAction("Error", "Home");
    }

    public async Task<IActionResult> DeleteNotification(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"http://localhost:7237/api/Notification/{ID}");
        
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Notification");
        }
        
        return RedirectToAction("Error", "Home");
    }

    public async Task<IActionResult> ActivateNotification(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:7237/api/Notification/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateNotificationDto>(json);

            if (value.Status)
            {
                value.Status = false;
                var responseMessagePut = await client.PutAsJsonAsync("http://localhost:7237/api/Notification",value);

                if (responseMessagePut.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Notification");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                value.Status = true;
                var responseMessagePut = await client.PutAsJsonAsync("http://localhost:7237/api/Notification",value);
                
                if (responseMessagePut.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Notification");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        return RedirectToAction("Error", "Home");
    }
}