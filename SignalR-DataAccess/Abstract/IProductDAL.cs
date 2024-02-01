using System;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.Abstract
{
	public interface IProductDAL : IGenericDAL<Product>
	{
		List<Product> GetProductswithCategories();

		int getProductCount();

		int getProductCountByCategoryDrink();
		
		int getProductCountByCategoryHamburger();

		decimal getBurgerAveragePrice();

		decimal getDrinkAveragePrice();

		string getProductByMinPrice();
		
		string getProductByMaxPrice();
	}
}

