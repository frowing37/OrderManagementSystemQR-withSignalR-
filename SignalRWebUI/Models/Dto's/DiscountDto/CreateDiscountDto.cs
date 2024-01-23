using System;
using SignalRWebUI.Models.Dtos.ProductDto;
using SignalRWebUI.Models.Dtos.CategoryDto;

namespace SignalRWebUI.Models.Dtos.DiscountDto
{
	public class CreateDiscountDto
	{
        public string Title { get; set; }

        public string Amount { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
        
    }
}

