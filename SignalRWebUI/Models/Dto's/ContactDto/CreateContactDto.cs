using System;
namespace SignalRWebUI.Models.Dtos.ContactDto
{
	public class CreateContactDto
	{
        public string Location { get; set; }
        
        public bool Status { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string FooterDescription { get; set; }
    }
}

