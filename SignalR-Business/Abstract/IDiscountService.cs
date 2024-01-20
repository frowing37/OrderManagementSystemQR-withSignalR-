using System;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Abstract
{
	public interface IDiscountService : IGenericService<Discount>
	{
		List<Discount> GetDiscountswithProductswS();

		List<ProductDiscount> GetProductDiscountswS();
	}
}

