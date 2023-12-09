﻿using System;
namespace SignalR_Dto.ProductDto
{
	public class UpdateProductDto
	{
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public bool ProductStatus { get; set; }
    }
}

