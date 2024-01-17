using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Models.Dtos.CategoryDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7237/api/Category");

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            //var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("http://localhost:7237/api/Category",createCategoryDto);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var apiResponse = await responseMessage.Content.ReadAsStringAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> DeleteCategory(int ID)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:7237/api/Category/{ID}");

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int ID)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:7237/api/Category/{ID}");

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);

                return View(values);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync("http://localhost:7237/api/Category",updateCategoryDto);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> UpdateActivate(int ID)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageGet = await client.GetAsync($"http://localhost:7237/api/Category/{ID}");
            
            if(responseMessageGet.IsSuccessStatusCode)
            {
                var jsonData = await responseMessageGet.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);

                if(values.Status)
                {
                    values.Status = false;
                    var responseMessageUpdate = await client.PutAsJsonAsync("http://localhost:7237/api/Category", values);

                    if(responseMessageUpdate.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Category");   
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }
;                }
                else
                {
                    values.Status = true;
                    var responseMessageUpdate = await client.PutAsJsonAsync("http://localhost:7237/api/Category", values);
                    
                    if(responseMessageUpdate.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Category");   
                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    
                    return RedirectToAction("Index", "Category");
                }
            }

            return RedirectToAction("Error", "Home");
        }
    }
}
