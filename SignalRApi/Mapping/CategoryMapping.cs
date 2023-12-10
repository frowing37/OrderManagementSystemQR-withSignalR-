using System;
using AutoMapper;
using SignalR_Dto.CategoryDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class CategoryMapping : Profile
	{
		public CategoryMapping()
		{
			CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
        }
	}
}

