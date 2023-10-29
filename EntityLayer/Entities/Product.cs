using EntityLayer.Entities.Base;
using Microsoft.AspNetCore.Http;
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
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public string? PictureUrl{ get; set; }
        public string? PictureUrl1{ get; set; }
        public string? PictureUrl2{ get; set; }
        public int Stock { get; set; }
    }
}
