using EntityLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Testimonial:BaseClass
	{
        public string? Name { get; set; }
        public string? Title{ get; set; }
        public string? Description{ get; set; }
    }
}
