using System;
namespace SignalR_Dto.TestimonialDto
{
	public class GetTestimonialDto
	{
        public int TestimonialID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string ImageURL { get; set; }

        public bool Status { get; set; }
    }
}

