using System;
namespace SignalRWebUI.Models.Dtos.SocialMediaDto
{
	public class GetSocialMediaDto
	{
        public int SocialMediaID { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public string Icon { get; set; }
    }
}

