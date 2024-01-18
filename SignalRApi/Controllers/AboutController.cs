using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Business.Concrete;
using SignalR_Dto.AboutDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.GetListAllwS();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout([FromBody] CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                ImageURL = createAboutDto.ImageURL,
                Title = createAboutDto.Title,
                Description = createAboutDto.Description
            };
            _aboutService.AddwS(about);

            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");
        }

        [HttpPut]
        public IActionResult UpdateAbout([FromBody] UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutID = updateAboutDto.AboutID,
                Description = updateAboutDto.Description,
                ImageURL = updateAboutDto.ImageURL,
                Status = updateAboutDto.Status,
                Title = updateAboutDto.Title
            };

            _aboutService.UpdatewS(about);
            return Ok("Hakkında alanı başarılı bir şekilde güncellendi");
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteAbout(int ID)
        {
            var value = _aboutService.GetByIDwS(ID);
            _aboutService.DeletewS(value);

            return Ok("Hakkında kısmı başarılı bir şekilde silindi");
        }

        [HttpGet("{ID}")]
        public IActionResult GetAbout(int ID)
        {
            var value = _aboutService.GetByIDwS(ID);

            return Ok(value);
        }
    }
}

