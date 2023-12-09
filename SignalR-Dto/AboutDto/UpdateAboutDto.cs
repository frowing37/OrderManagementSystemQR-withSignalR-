using System;
namespace SignalR_Dto.AboutDto
{
	public class UpdateAboutDto
	{
        public int AboutID { get; set; }

        public string ImageURL { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}

