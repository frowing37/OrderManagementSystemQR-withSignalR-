using System;
using AutoMapper;
using SignalR_Dto.BookingDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class BookingMapping : Profile
	{
		public BookingMapping()
		{
			CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        }
	}
}

