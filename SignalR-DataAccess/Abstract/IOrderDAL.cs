using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.Abstract;

public interface IOrderDAL : IGenericDAL<Order>
{
    int TotalOrderCount();

    int ActiveOrderCount();
}