using EntityLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Category:BaseClass
	{
		public string Name { get; set; } = null!;
		public List<Product>? Products { get; set; }
		public bool Status { get; set; }
    }
}
