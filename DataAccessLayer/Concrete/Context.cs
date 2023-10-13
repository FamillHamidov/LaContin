using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context:DbContext
	{
        public Context(DbContextOptions<Context> options):base(options)
        {
        }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products{ get; set; }
       public DbSet<About> Abouts{ get; set; }
       public DbSet<GetInTouch> GetInTouches{ get; set; }
       public DbSet<Testimonial> Testimonials{ get; set; }
       public DbSet<Login> Logins{ get; set; }
       public DbSet<TitleSlider> TitleSliders{ get; set; }
       public DbSet<Logo> Logos{ get; set; }
    }
}
