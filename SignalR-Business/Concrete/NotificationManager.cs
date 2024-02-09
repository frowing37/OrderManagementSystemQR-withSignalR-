using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete;

public class NotificationManager : INotificationService
{
    private readonly INotificationDAL _notificationDal;

    public NotificationManager(INotificationDAL notificationDal)
    {
        _notificationDal = notificationDal;
    }

    public void AddwS(Notification t)
    {
        _notificationDal.Insert(t);
    }

    public void UpdatewS(Notification t)
    {
        _notificationDal.Update(t);
    }

    public void DeletewS(Notification t)
    {
        _notificationDal.Delete(t);
    }

    public Notification GetByIDwS(int ID)
    {
        return _notificationDal.GetByID(ID);
    }

    public List<Notification> GetListAllwS()
    {
        return _notificationDal.GetListAll();
    }

    public int getNotificationCountByStatusFalsewS()
    {
        return _notificationDal.getNotificationCountByStatusFalse();
    }

    public List<Notification> getAllNotificationsByFalse()
    {
        return _notificationDal.getAllNotificationsByFalse();
    }
}