using EntityLayer.Dtos;
using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ProductValidator:AbstractValidator<Product>
	{
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad sahəsi tələb olunur");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıqlama sahəsi tələb olunur");
            RuleFor(x => x.Description).MinimumLength(100).WithMessage("Ən azı 100 simvol daxil edilməlidir");
            RuleFor(x => x.NewPrice).NotEmpty().WithMessage("Yeni qiymət sahəsi tələb olunur");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Yeni qiymət sahəsi tələb olunur");
        }
    }
}
