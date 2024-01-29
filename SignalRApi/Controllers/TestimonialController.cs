using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.TestimonialDto;
using AutoMapper;
using SignalR_Entities.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class TestimonialController : Controller
    {
        protected readonly ITestimonialService _testimonialService;
        protected readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.GetListAllwS());

            return Ok(values);
        }

        [HttpGet("{ID}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.GetListAllwS();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial([FromBody] CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Name = createTestimonialDto.Name,
                Title =createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                ImageURL = createTestimonialDto.ImageURL,
                Status = createTestimonialDto.Status
            };

            _testimonialService.AddwS(testimonial);

            return Ok("Referans eklendi");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial([FromBody] UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                ImageURL = updateTestimonialDto.ImageURL,
                Status = updateTestimonialDto.Status
            };

            _testimonialService.UpdatewS(testimonial);

            return Ok("Referans güncellendi");
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteTestimonial(int ID)
        {
            var value = _testimonialService.GetByIDwS(ID);

            _testimonialService.DeletewS(value);

            return Ok("Referans silindi");
        }
    }
}

