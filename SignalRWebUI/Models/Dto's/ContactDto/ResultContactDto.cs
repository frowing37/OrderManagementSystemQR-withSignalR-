﻿using System;
namespace SignalRWebUI.Models.Dtos.ContactDto
{
	public class ResultContactDto
	{
        public int ContactID { get; set; }

        public bool Status { get; set; }
        public string Location { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string FooterDescription { get; set; }
    }
}

