using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete;

public class OrderDetailManager : IOrderDetailService
{
    private readonly IOrderDetailDAL _orderDetailDAL;

    public OrderDetailManager(IOrderDetailDAL orderDetailDAL)
    {
        _orderDetailDAL = orderDetailDAL;
    }

    public void AddwS(OrderDetail t)
    {
        _orderDetailDAL.Insert(t);
    }

    public void UpdatewS(OrderDetail t)
    {
        _orderDetailDAL.Update(t);
    }

    public void DeletewS(OrderDetail t)
    {
        _orderDetailDAL.Delete(t);
    }

    public OrderDetail GetByIDwS(int ID)
    {
        return _orderDetailDAL.GetByID(ID);
    }

    public List<OrderDetail> GetListAllwS()
    {
        return _orderDetailDAL.GetListAll();
    }
}