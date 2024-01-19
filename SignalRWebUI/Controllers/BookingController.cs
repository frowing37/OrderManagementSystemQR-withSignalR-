using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.BookingDto;

namespace SignalRWebUI.Controllers;

public class BookingController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public BookingController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Booking");

        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);

            return View(values);
        }
        
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> CreateBooking()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Booking", createBookingDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Booking");
        }
        
        return RedirectToAction("Error", "Home");
    }
    [HttpGet]
    public async Task<IActionResult> UpdateBooking(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:7237/api/Booking/{ID}");
        
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);

            return View(value);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    [HttpPost]
    public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage =
            await client.PutAsJsonAsync("http://localhost:7237/api/Booking", updateBookingDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Booking");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    public async Task<IActionResult> DeleteBooking(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:7237/api/Booking/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Booking");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
}