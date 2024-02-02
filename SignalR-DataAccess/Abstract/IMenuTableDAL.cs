using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.Abstract;

public interface IMenuTableDAL : IGenericDAL<MenuTable>
{
    int getMenuTableCount();
}