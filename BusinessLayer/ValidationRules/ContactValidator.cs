using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Boş Bırakamazsın");            
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("en az 3 karakter");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("en fazla 50 karakter");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("en az 3 karakter");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("en fazla 20 karakter");
            RuleFor(x => x.Message).MaximumLength(20).WithMessage("en fazla 500 karakter");

        }
    }
}
