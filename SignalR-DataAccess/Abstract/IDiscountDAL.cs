﻿using System;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.Abstract
{
	public interface IDiscountDAL : IGenericDAL<Discount>
	{
		//List<Discount> GetDiscountswithProducts();

		List<Discount> GetDiscountswithProduct();
	}
}

