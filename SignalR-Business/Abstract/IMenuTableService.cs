using SignalR_Entities.Concrete;

namespace SignalR_Business.Abstract;

public interface IMenuTableService : IGenericService<MenuTable>
{
    int getMenuTableCountwS();
}