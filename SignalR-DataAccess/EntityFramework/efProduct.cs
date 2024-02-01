using System;
using SignalR_Entities.Concrete;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Repositories;
using SignalR_DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace SignalR_DataAccess.EntityFramework
{
    public class efProduct : GenericRepository<Product>, IProductDAL
    {
        public efProduct(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductswithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();

            return values;
        }

        public int getProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public int getProductCountByCategoryHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(p =>
                p.CategoryID == (context.Categories.Where(c => c.Name == "Burger").Select(c => c.CategoryID)
                    .FirstOrDefault())).Count();
        }

        public decimal getBurgerAveragePrice()
        {
            using var context = new SignalRContext();
            return context.Products.Where(p =>
                p.CategoryID == (context.Categories.Where(c => c.Name == "Burger").Select(c => c.CategoryID)
                    .FirstOrDefault())).Average(x => x.Price);
        }

        public decimal getDrinkAveragePrice()
        {
            using var context = new SignalRContext();
            return context.Products.Where(p =>
                p.CategoryID == (context.Categories.Where(c => c.Name == "İçecek").Select(c => c.CategoryID)
                    .FirstOrDefault())).Average(x => x.Price);
        }

        public string getProductByMinPrice()
        {
            using var context = new SignalRContext();
            return context.Products.Where(p => p.Price == (context.Products.Min(p => p.Price)))
                .Select(n => n.ProductName).FirstOrDefault();
        }

        public string getProductByMaxPrice()
        {
            using var context = new SignalRContext();
            return context.Products.Where(p => p.Price == (context.Products.Max(p => p.Price)))
                .Select(n => n.ProductName).FirstOrDefault();
        }

        public int getProductCountByCategoryDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Where(p =>
                p.CategoryID == (context.Categories.Where(c => c.Name == "İçecek").Select(c => c.CategoryID)
                    .FirstOrDefault())).Count();
        }
    }
}

