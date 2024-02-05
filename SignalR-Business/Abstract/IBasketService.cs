using SignalR_Entities.Concrete;

namespace SignalR_Business.Abstract;

public interface IBasketService : IGenericService<Basket>
{
    List<Basket> getBasketByMenuTablewS(int ID);
}