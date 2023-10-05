using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class TitleSliderDto
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Picture{ get; set; }
    }
}
