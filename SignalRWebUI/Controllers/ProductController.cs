using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.CategoryDto;
using SignalRWebUI.Models.Dto_s.ProductDto;

namespace SignalRWebUI.Controllers;

public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Product/ProductListwithCategories");

        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

            return View(values);
        }
        
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Category");

        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> values2 = (from x in values
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryID.ToString()
                }).ToList();

            ViewBag.Categories = values2;

            return View();
        }
        
        return RedirectToAction("Error", "Home");
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Product", createProductDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Product");
        }
        
        return RedirectToAction("Error", "Home");
    }
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Category");
        var responseMessage2 = await client.GetAsync($"http://localhost:7237/api/Product/{ID}");
        
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> values2 = (from x in values
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryID.ToString()
                }).ToList();

            ViewBag.Categories = values2;

            if(responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData2);
                
                return View(values3);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage =
            await client.PutAsJsonAsync("http://localhost:7237/api/Product", updateProductDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Product");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    public async Task<IActionResult> UpdateActivate(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:7237/api/Product/{ID}");

        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

            if (value.ProductStatus)
            {
                value.ProductStatus = false;
                var responseMessageUpdate = 
                    await client.PutAsJsonAsync("http://localhost:7237/api/Product", value);

                if(responseMessageUpdate.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Product");   
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                value.ProductStatus = true;
                var responseMessageUpdate = 
                    await client.PutAsJsonAsync("http://localhost:7237/api/Product", value);
                
                if(responseMessageUpdate.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Product");   
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
                
                return RedirectToAction("Index", "Product");
            }
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    public async Task<IActionResult> DeleteProduct(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:7237/api/Product/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Product");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
}