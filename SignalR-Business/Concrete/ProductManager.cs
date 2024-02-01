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

        public List<Product> GetProductswithCategorieswS()
        {
            return _productDAL.GetProductswithCategories();
        }

        public int getProductCountwS()
        {
            return _productDAL.getProductCount();
        }

        public int getProductCountCategoryByDrinkwS()
        {
            return _productDAL.getProductCountByCategoryDrink();
        }

        public int getProductCountCategoryByBurgerwS()
        {
            return _productDAL.getProductCountByCategoryHamburger();
        }

        public decimal getDrinkAveragePricewS()
        {
            return _productDAL.getDrinkAveragePrice();
        }

        public decimal getBurgerAveragePricewS()
        {
            return _productDAL.getBurgerAveragePrice();
        }

        public string getProductByMaxPricewS()
        {
            return _productDAL.getProductByMaxPrice();
        }

        public string getProductByMinPricewS()
        {
            return _productDAL.getProductByMinPrice();
        }

        public void UpdatewS(Product t)
        {
            _productDAL.Update(t);
        }
    }
}

