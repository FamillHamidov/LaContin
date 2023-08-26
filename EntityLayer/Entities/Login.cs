using EntityLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class Login:BaseClass
	{
        public string? Name { get; set; } 
        public string? Surname { get; set; } 
		public string? Username { get; set; }
        public string? Password { get; set; } 
        public string? Email { get; set; } 
    }
}
