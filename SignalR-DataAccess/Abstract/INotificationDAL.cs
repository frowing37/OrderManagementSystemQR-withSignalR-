using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.Abstract;

public interface INotificationDAL : IGenericDAL<Notification>
{
    int getNotificationCountByStatusFalse();
    List<Notification> getAllNotificationsByFalse();
}