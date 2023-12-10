using System;
using AutoMapper;
using SignalR_Dto.TestimonialDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class TestimonialMapping : Profile
	{
		public TestimonialMapping()
		{
			CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
        }
	}
}

