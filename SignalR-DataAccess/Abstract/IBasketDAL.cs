using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.Abstract;

public interface IBasketDAL : IGenericDAL<Basket>
{
    List<Basket> getBasketByMenuTable(int ID);
}