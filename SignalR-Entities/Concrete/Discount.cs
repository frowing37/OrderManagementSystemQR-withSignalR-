using System;
namespace SignalR_Entities.Concrete
{
	public class Discount
	{
		public int DiscountID { get; set; }

		public string Title { get; set; }

		public string Amount { get; set; }

		public string Description { get; set; }

		public string ImageURL { get; set; }
		
		public List<ProductDiscount> ProductDiscounts { get; set; }
	}
}

