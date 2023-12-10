using System;
using AutoMapper;
using SignalR_Dto.ContactDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class ContactMapping : Profile
	{
		public ContactMapping()
		{
			CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
        }
	}
}

