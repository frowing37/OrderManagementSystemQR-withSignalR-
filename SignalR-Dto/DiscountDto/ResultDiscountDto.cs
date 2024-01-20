using System;
using SignalR_Entities.Concrete;

namespace SignalR_Dto.DiscountDto
{
	public class ResultDiscountDto
	{
        public int DiscountID { get; set; }

        public string Title { get; set; }

        public string Amount { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
        
        public List<Product> Products { get; set; }
    }
}

