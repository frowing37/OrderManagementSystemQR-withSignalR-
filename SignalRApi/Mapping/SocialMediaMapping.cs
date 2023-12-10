using System;
using AutoMapper;
using SignalR_Dto.SocialMediaDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class SocialMediaMapping : Profile
	{
		public SocialMediaMapping()
		{
			CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
        }
	}
}

