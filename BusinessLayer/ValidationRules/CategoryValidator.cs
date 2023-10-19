using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator:AbstractValidator<Category>
	{
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad sahəsi tələb olunur");
        }
    }
}
