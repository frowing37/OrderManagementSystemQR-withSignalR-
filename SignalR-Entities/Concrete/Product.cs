﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR_Entities.Concrete
{
	public class Product
	{
		public int ProductID { get; set; }

		public string ProductName { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public string ImageURL { get; set; }

		public bool ProductStatus { get; set; }

		[ForeignKey("Category")]

		public int CategoryID { get; set; }

		public Category Category { get; set; }
		
		public List<ProductDiscount> ProductDiscounts { get; set; }
		
		public List<OrderDetail> OrderDetails { get; set; }
	}
}

