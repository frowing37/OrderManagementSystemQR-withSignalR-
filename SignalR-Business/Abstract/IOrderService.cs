using SignalR_Entities.Concrete;

namespace SignalR_Business.Abstract;

public interface IOrderService : IGenericService<Order>
{
    int TotalOrderCountwS();
    int ActiveOrderCountwS();
    decimal LastOrderPrice();
}