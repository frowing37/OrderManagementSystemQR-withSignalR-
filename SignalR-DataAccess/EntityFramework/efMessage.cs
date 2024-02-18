using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;
using SignalR_DataAccess.Repositories;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.EntityFramework;

public class efMessage : GenericRepository<Message>,IMessageDAL
{
    public efMessage(SignalRContext context) : base(context)
    {
    }
}