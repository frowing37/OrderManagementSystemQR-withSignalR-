﻿using System;
namespace SignalRWebUI.Models.Dtos.CategoryDto
{
	public class UpdateCategoryDto
	{
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }
    }
}

