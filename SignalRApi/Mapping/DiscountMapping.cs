using System;
using AutoMapper;
using SignalR_Dto.DiscountDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class DiscountMapping : Profile
	{
		public DiscountMapping()
		{
			CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
        }
	}
}

