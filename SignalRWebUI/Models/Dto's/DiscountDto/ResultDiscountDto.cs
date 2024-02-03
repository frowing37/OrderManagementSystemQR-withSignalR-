using System;
namespace SignalRWebUI.Models.Dtos.DiscountDto
{
	public class ResultDiscountDto
	{
        public int DiscountID { get; set; }

        public string Title { get; set; }

        public string Amount { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
        
        public int ProductID { get; set; }
        
        public string ProductName { get; set; }
    }
}

