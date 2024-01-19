using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Models.Dtos.ContactDto;
using Newtonsoft.Json;

namespace SignalRWebUI.Controllers;

public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:7237/api/Contact");

        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

            return View(values);
        }
        
        return RedirectToAction("Error","Home");
    }
    [HttpGet]
    public async Task<IActionResult> CreateContact()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Contact", createContactDto);

        if(responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Contact");
        }
        
        return RedirectToAction("Error", "Home");
    }
    [HttpGet]
    public async Task<IActionResult> UpdateContact(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:7237/api/Contact/{ID}");
        
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);

            return View(value);
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    [HttpPost]
    public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage =
            await client.PutAsJsonAsync("http://localhost:7237/api/Contact", updateContactDto);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Contact");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    
    public async Task<IActionResult> DeleteContact(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:7237/api/Contact/{ID}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Contact");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    public async Task<IActionResult> UpdateActivate(int ID)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessageAll = await client.GetAsync("http://localhost:7237/api/Contact");

        if(responseMessageAll.IsSuccessStatusCode)
        {
            var jsonAboutAll = await responseMessageAll.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<UpdateContactDto>>(jsonAboutAll);
            UpdateContactDto temp = new UpdateContactDto();
            
            foreach (var contact in values)
            {
                if (contact.ContactID == ID)
                {
                    temp.ContactID = contact.ContactID;
                    temp.Status = contact.Status;
                    temp.Location = contact.Location;
                    temp.Phone = contact.Phone;
                    temp.Mail = contact.Mail;
                    temp.FooterDescription = contact.FooterDescription;
                    values.Remove(contact);
                    break;
                }
            }

            if (temp.Status)
            {
                temp.Status = false;
                HttpResponseMessage rmT = await client.PutAsJsonAsync("http://localhost:7237/api/Contact", temp);

                Random rnd = new Random();
                int rand = rnd.Next(0, values.Count);

                values[rand].Status = true;
                HttpResponseMessage rmR = await client.PutAsJsonAsync("http://localhost:7237/api/Contact", values[rand]);

                return RedirectToAction("Index", "Contact");
            }
            else
            {
                temp.Status = true;
                HttpResponseMessage rmT = await client.PutAsJsonAsync("http://localhost:7237/api/Contact", temp);

                foreach (var contact in values)
                {
                    contact.Status = false;
                    HttpResponseMessage rmTt = await client.PutAsJsonAsync("http://localhost:7237/api/Contact", contact);
                }
                
                return RedirectToAction("Index", "Contact");
            }
            
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
}