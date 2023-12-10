using System;
using AutoMapper;
using SignalR_Dto.ProductDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class ProductMapping : Profile
	{
		public ProductMapping()
		{
			CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
        }
	}
}

