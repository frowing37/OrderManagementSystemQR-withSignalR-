using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.TestimonialDto;

namespace SignalRWebUI.Controllers;

public class TestimonialController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TestimonialController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Testimonial");

        if(responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(json);

            return View(values);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    [HttpGet]
    public IActionResult CreateTestimonial()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Testimonial", createTestimonialDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Testimonial");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateTestimonial(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Testimonial/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(json);

            return View(value);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PutAsJsonAsync("http://localhost:7237/api/Testimonial", updateTestimonialDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Testimonial");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    public async Task<IActionResult> DeleteTestimonial(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("http://localhost:7237/api/Testimonial/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Testimonial");
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

}