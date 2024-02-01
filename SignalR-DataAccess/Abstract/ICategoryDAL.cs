using System;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.Abstract
{
	public interface ICategoryDAL : IGenericDAL<Category>
	{
		int getCategoryCount();

		int getActiveCategory();

		int getPassiveCategory();
	}
}

