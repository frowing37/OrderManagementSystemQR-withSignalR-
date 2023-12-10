using System;
using AutoMapper;
using SignalR_Dto.FeatureDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Mapping
{
	public class FeatureMapping : Profile
	{
		public FeatureMapping()
		{
			CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
        }
	}
}

