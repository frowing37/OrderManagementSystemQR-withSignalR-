using SignalR_Entities.Concrete;

namespace SignalR_Business.Abstract;

public interface INotificationService : IGenericService<Notification>
{
    int getNotificationCountByStatusFalsewS();

    List<Notification> getAllNotificationsByFalse();
}