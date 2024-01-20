using System;
namespace SignalR_Dto.DiscountDto
{
	public class CreateDiscountDto
	{
        public string Title { get; set; }

        public string Amount { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
        
        public List<int> ProductID { get; set; }
    }
}

