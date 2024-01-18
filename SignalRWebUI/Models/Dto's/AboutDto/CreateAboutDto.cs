using System;
namespace SignalRWebUI.Models.Dtos.AboutDto
{
	public class CreateAboutDto
	{
        public string ImageURL { get; set; }
        
        public bool Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}

