using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDAL _orderDAL;

    public OrderManager(IOrderDAL orderDAL)
    {
        _orderDAL = orderDAL;
    }
    
    public void AddwS(Order t)
    {
        _orderDAL.Insert(t);
    }

    public void UpdatewS(Order t)
    {
        _orderDAL.Update(t);
    }

    public void DeletewS(Order t)
    {
        _orderDAL.Delete(t);
    }

    public Order GetByIDwS(int ID)
    {
        return _orderDAL.GetByID(ID);
    }

    public List<Order> GetListAllwS()
    {
        return _orderDAL.GetListAll();
    }

    public int TotalOrderCountwS()
    {
        return _orderDAL.TotalOrderCount();
    }

    public int ActiveOrderCountwS()
    {
        return _orderDAL.ActiveOrderCount();
    }

    public decimal LastOrderPrice()
    {
        return _orderDAL.LastOrderPrice();
    }
}