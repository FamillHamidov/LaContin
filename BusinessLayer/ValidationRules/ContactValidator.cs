using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator:AbstractValidator<Contact> 
	{
        public ContactValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq sahəsi tələb olunur");
            RuleFor(x => x.FirstSocialMedia).NotEmpty().WithMessage("Sosial Media 1 sahəsi tələb olunur");
            RuleFor(x => x.FirstUrlOrNumber).NotEmpty().WithMessage("Link 1 sahəsi tələb olunur");
        }
    }
}
