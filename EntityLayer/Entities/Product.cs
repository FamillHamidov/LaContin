using EntityLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Product:BaseClass
	{
        public string? Name { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public string? Description  { get; set; }
    }
}
