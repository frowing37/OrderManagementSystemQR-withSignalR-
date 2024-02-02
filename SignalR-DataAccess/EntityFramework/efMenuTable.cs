using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;
using SignalR_DataAccess.Repositories;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.EntityFramework;

public class efMenuTable : GenericRepository<MenuTable>, IMenuTableDAL
{
    public efMenuTable(SignalRContext context) : base(context)
    {
    }

    public int getMenuTableCount()
    {
        using var context = new SignalRContext();
        return context.MenuTables.Count();
    }
}