using System;
namespace SignalR_Dto.SocialMediaDto
{
	public class UpdateSocialMediaDto
	{
        public int SocialMediaID { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public string Icon { get; set; }
    }
}

