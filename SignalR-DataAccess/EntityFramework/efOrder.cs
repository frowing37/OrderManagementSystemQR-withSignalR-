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
}