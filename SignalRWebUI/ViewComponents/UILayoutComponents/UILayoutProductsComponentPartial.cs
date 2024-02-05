using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.ProductDto;

namespace SignalRWebUI.ViewComponents.UILayoutComponents;

public class UILayoutProductsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UILayoutProductsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Product/ProductListwithCategories");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(json);

            return View(values);
        }

        return View();
    }
}