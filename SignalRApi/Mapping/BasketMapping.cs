using AutoMapper;
using SignalR_Dto.BasketDto;
using SignalR_Entities.Concrete;
using ResultBasketDto = SignalRWebUI.Models.Dtos.BasketDto.ResultBasketDto;

namespace SignalRApi.Mapping;

public class BasketMapping : Profile
{
    public BasketMapping()
    {
        CreateMap<Basket, CreateBasketDto>().ReverseMap();
        CreateMap<Basket, UpdateBasketDto>().ReverseMap();
        CreateMap<Basket, ResultBasketDto>().ReverseMap();
        CreateMap<Basket, GetBasketDto>().ReverseMap();
    }
}