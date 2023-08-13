using EntityLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
	public class GetInTouch:BaseClass
	{
        public string? Email { get; set; }
        public string? Phone{ get; set; }
        public string? Address{ get; set; }
    }
}
