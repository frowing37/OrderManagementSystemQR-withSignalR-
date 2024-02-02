using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;
using SignalR_DataAccess.Repositories;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.EntityFramework;

public class efOrder : GenericRepository<Order>, IOrderDAL
{
    public efOrder(SignalRContext context) : base(context)
    {
    }

    public int TotalOrderCount()
    {
        using var context = new SignalRContext();
        return context.Orders.Count();
    }

    public int ActiveOrderCount()
    {
        using var context = new SignalRContext();
        return context.Orders.Where(o => o.Status == true).Count();
    }

    public decimal LastOrderPrice()
    {
        using var context = new SignalRContext();
        return context.Orders.OrderByDescending(o => o.OrderID).Take(1).Select(o => o.TotalPrice).FirstOrDefault();
    }
}