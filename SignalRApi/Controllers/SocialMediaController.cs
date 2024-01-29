using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.SocialMediaDto;
using SignalR_Entities.Concrete;
using AutoMapper;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class SocialMediaController : Controller
    {
        protected readonly ISocialMediaService _socialMediaService;
        protected readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.GetListAllwS());

            return Ok(values);
        }

        [HttpGet("{ID}")]
        public IActionResult GetSocialMedia(int ID)
        {
            var value = _socialMediaService.GetByIDwS(ID);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia([FromBody] CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Title = createSocialMediaDto.Title,
                URL = createSocialMediaDto.URL,
                Icon = createSocialMediaDto.Icon
            };

            _socialMediaService.AddwS(socialMedia);

            return Ok("Medya eklendi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia([FromBody] UpdateSocialMediaDto updateSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Title = updateSocialMediaDto.Title,
                URL = updateSocialMediaDto.URL,
                Icon = updateSocialMediaDto.Icon
            };

            _socialMediaService.UpdatewS(socialMedia);

            return Ok("Medya güncellendi");
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteSocialMedia(int ID)
        {
            var value = _socialMediaService.GetByIDwS(ID);

            _socialMediaService.DeletewS(value);

            return Ok("Medya silindi");
        }
    }
}

