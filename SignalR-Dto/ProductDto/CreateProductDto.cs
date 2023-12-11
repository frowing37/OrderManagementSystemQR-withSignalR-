﻿using System;
using SignalR_Entities.Concrete;

namespace SignalR_Dto.ProductDto
{
	public class CreateProductDto
	{
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public bool ProductStatus { get; set; }
    }
}

