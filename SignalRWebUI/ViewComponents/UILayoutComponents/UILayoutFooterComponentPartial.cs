using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.Dtos.ContactDto;

namespace SignalRWebUI.ViewComponents.UILayoutComponents;

public class UILayoutFooterComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public UILayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Contact");

        if (responseMessage.IsSuccessStatusCode)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(json);
            ResultContactDto val = new ResultContactDto();

            foreach (var value in values)
            {
                if (value.Status)
                {
                    val.Location = value.Location;
                    val.Mail = value.Mail;
                    val.Phone = value.Phone;
                    val.FooterDescription = value.FooterDescription;
                    break;
                }
            }

            return View(val);
        }
        
        return View();
    }
}