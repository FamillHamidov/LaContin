using EntityLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Contact:BaseClass
	{
        public string? Title { get; set; }
        public string? FirstSocialMedia { get; set; }
        public string? FirstUrlOrNumber { get; set; }
        public string? SecondSocialMedia { get; set; }
        public string? SecondUrlOrNumber { get; set; }
    }
}
