﻿using EntityLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class About:BaseClass
	{
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl{ get; set; }
    }
}
