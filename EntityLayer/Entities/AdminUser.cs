using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class AdminUser:IdentityUser<int>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }
}
