using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class TestimonialValidator:AbstractValidator<Testimonial>
	{
        public TestimonialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad və soyad sahəsi tələb olunur");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq sahəsi tələb olunur");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıqlama sahəsi tələb olunur");
        }
    }
}
