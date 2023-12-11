using System;
using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete
{
    public class ProductManager : IProductService
    {
        protected readonly IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void AddwS(Product t)
        {
            _productDAL.Insert(t);
        }

        public void DeletewS(Product t)
        {
            _productDAL.Delete(t);
        }

        public Product GetByIDwS(int ID)
        {
            return _productDAL.GetByID(ID);
        }

        public List<Product> GetListAllwS()
        {
            return _productDAL.GetListAll();
        }

        public List<Product> GetProductswithCategories()
        {
            return _productDAL.GetProductswithCategories();
        }

        public void UpdatewS(Product t)
        {
            _productDAL.Update(t);
        }
    }
}

