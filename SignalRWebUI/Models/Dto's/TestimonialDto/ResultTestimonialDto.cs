﻿using System;
namespace SignalRWebUI.Models.Dtos.TestimonialDto
{
	public class ResultTestimonialDto
	{
        public int TestimonialID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string ImageURL { get; set; }

        public bool Status { get; set; }
    }
}

