using System;
using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        protected readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void AddwS(Category t)
        {
            _categoryDAL.Insert(t);
        }

        public void DeletewS(Category t)
        {
            _categoryDAL.Delete(t);
        }

        public Category GetByIDwS(int ID)
        {
            return _categoryDAL.GetByID(ID);
        }

        public List<Category> GetListAllwS()
        {
            return _categoryDAL.GetListAll();
        }

        public void UpdatewS(Category t)
        {
            _categoryDAL.Update(t);
        }
    }
}

