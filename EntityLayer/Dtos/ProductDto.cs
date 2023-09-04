﻿using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
	public class ProductDto
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public  List<Category>? Categories { get; set; }
        public string? PictureUrl { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
