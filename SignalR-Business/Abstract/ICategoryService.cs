using System;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Abstract
{
	public interface ICategoryService : IGenericService<Category>
	{
		int getCategoryCountwS();
	}
}

