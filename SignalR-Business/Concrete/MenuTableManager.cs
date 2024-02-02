using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete;

public class MenuTableManager : IMenuTableService
{
    private readonly IMenuTableDAL _menuTableDAL;

    public MenuTableManager(IMenuTableDAL menuTableDal)
    {
        _menuTableDAL = menuTableDal;
    }

    public void AddwS(MenuTable t)
    {
        _menuTableDAL.Insert(t);
    }

    public void UpdatewS(MenuTable t)
    {
        _menuTableDAL.Update(t);
    }

    public void DeletewS(MenuTable t)
    {
        _menuTableDAL.Delete(t);
    }

    public MenuTable GetByIDwS(int ID)
    {
        return _menuTableDAL.GetByID(ID);
    }

    public List<MenuTable> GetListAllwS()
    {
        return _menuTableDAL.GetListAll();
    }

    public int getMenuTableCountwS()
    {
        return _menuTableDAL.getMenuTableCount();
    }
}