using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;
using SignalR_DataAccess.Repositories;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.EntityFramework;

public class efOrderDetail : GenericRepository<OrderDetail>, IOrderDetailDAL
{
    public efOrderDetail(SignalRContext context) : base(context)
    {
    }
}