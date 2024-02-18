using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete;

public class MessageManager : IMessageService
{
    private readonly IMessageDAL _messageDal;

    public MessageManager(IMessageDAL messageDAL)
    {
        _messageDal = messageDAL;
    }
    
    public void AddwS(Message t)
    {
        _messageDal.Insert(t);
    }

    public void UpdatewS(Message t)
    {
        _messageDal.Update(t);
    }

    public void DeletewS(Message t)
    {
        _messageDal.Delete(t);
    }

    public Message GetByIDwS(int ID)
    {
        return _messageDal.GetByID(ID);
    }

    public List<Message> GetListAllwS()
    {
        return _messageDal.GetListAll();
    }
}