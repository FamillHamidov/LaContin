﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
	public class AboutDto
	{
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description{ get; set; }
        public string? PictureUrl{ get; set; }
        public IFormFile? Picture{ get; set; }
    }
}
