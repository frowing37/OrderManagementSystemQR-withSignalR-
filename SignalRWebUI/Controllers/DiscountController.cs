using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.CategoryDto;
using SignalRWebUI.Models.Dtos.DiscountDto;
using SignalRWebUI.Models.Dtos.ProductDto;

namespace SignalRWebUI.Controllers;

public class DiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DiscountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> CreateDiscount()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        var responseMessageCategories = await client.GetAsync("http://localhost:7237/api/Category");
        var responseMessageProducts = await client.GetAsync("http://localhost:7237/api/Product");

        if(responseMessageCategories.IsSuccessStatusCode && responseMessageProducts.IsSuccessStatusCode)
        {
            var jsonCategories = await responseMessageCategories.Content.ReadAsStringAsync();
            var jsonProducts = await responseMessageProducts.Content.ReadAsStringAsync();
            var valuesCategories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategories);
            var valuesProducts = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonProducts);

            List<SelectListItem> valuesCategory = (from x in valuesCategories
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryID.ToString()
                }).ToList();
            
            List<SelectListItem> valuesProduct = (from x in valuesProducts
                select new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductID.ToString()
                }).ToList();

            ViewBag.Categories = valuesCategory;
            ViewBag.Products = valuesProduct;
            
            return View();
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Discount",createDiscountDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Discount");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    [HttpGet]
    public async Task<IActionResult> UpdateDiscount(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessageDiscount = await client.GetAsync($"http://localhost:7237/api/Discount/{ID}");
        HttpResponseMessage responseMessageCategories = await client.GetAsync($"http://localhost:7237/api/Category");
        HttpResponseMessage responseMessageProducts = await client.GetAsync($"http://localhost:7237/api/Product");

        if(responseMessageDiscount.IsSuccessStatusCode && responseMessageCategories.IsSuccessStatusCode && responseMessageProducts.IsSuccessStatusCode)
        {
            var jsonDiscount = await responseMessageDiscount.Content.ReadAsStringAsync();
            var jsonCategories = await responseMessageCategories.Content.ReadAsStringAsync();
            var jsonProducts = await responseMessageProducts.Content.ReadAsStringAsync();
            var valuesDiscount = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonDiscount);
            var valuesCategories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategories);
            var valuesProducts = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonProducts);
            
            List<SelectListItem> valuesCategory = (from x in valuesCategories
                    select new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.CategoryID.ToString()
                    }).ToList();
            
            List<SelectListItem> valuesProduct = (from x in valuesProducts
                select new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductID.ToString()
                }).ToList();

            ViewBag.Categories = valuesCategory;
            ViewBag.Products = valuesProduct;

            return View(valuesDiscount);
        }

        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
    {
        var client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.PutAsJsonAsync("http://localhost:7237/api/Discount",updateDiscountDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Discount");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    public async Task<IActionResult> Delete(int ID)
    {
        var client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:7237/api/Discount/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Discount");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    
}