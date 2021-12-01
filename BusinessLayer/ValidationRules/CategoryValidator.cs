using EntityLayer.Concrete;
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
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("en az 3 karakter");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("en fazla 20 karakter");
        }
    }
}
