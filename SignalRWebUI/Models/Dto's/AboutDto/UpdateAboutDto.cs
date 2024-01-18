using System;
namespace SignalRWebUI.Models.Dtos.AboutDto
{
	public class UpdateAboutDto
	{
        public int AboutID { get; set; }

        public string ImageURL { get; set; }
        
        public bool Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}

