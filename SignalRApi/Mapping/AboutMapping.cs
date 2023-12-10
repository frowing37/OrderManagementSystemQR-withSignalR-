using System;
using AutoMapper;
using SignalR_Dto.AboutDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class AboutMapping : Profile
	{
		public AboutMapping()
		{
			CreateMap<About, ResultAboutDto>().ReverseMap();
			CreateMap<About, UpdateAboutDto>().ReverseMap();
			CreateMap<About, GetAboutDto>().ReverseMap();
			CreateMap<About, CreateAboutDto>().ReverseMap();
		}
	}
}

