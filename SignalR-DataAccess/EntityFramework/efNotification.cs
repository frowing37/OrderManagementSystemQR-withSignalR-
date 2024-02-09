using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;
using SignalR_DataAccess.Repositories;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.EntityFramework;

public class efNotification : GenericRepository<Notification>, INotificationDAL
{
    public efNotification(SignalRContext context) : base(context)
    {
    }

    public int getNotificationCountByStatusFalse()
    {
        using var context = new SignalRContext();
        return context.Notifications.Where(x => x.Status == false).Count();
    }

    public List<Notification> getAllNotificationsByFalse()
    {
        using var context = new SignalRContext();
        return context.Notifications.Where(x => x.Status == false).ToList();
    }
}