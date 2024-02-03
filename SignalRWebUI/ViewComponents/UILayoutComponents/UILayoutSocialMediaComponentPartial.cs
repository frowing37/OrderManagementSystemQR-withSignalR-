using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.SocialMediaDto;

namespace SignalRWebUI.ViewComponents.UILayoutComponents;

public class UILayoutSocialMediaComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/SocialMedia");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(json);

            return View(values);
        }
        
        return View();
    }
}