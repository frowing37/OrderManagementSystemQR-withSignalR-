using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.FeatureDto;

namespace SignalRWebUI.ViewComponents.UILayoutComponents;

public class UILayoutSliderComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UILayoutSliderComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Feature");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(json);
            
            return View(values);
        }

        return View();
    }
    
    
}