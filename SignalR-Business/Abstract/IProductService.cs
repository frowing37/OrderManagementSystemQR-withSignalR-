﻿using System;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
		List<Product> GetProductswithCategories();
	}
}

