using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR_Entities.Concrete
{
	public class Discount
	{
		public int DiscountID { get; set; }

		public string Title { get; set; }

		public string Amount { get; set; }

		public string Description { get; set; }

		public string ImageURL { get; set; }
		
		[ForeignKey("Product")]
		
		public int ProductID { get; set; }
		
		public Product Product { get; set; }
	}
}

