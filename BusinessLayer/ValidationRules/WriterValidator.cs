using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("en az 3 karakter");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("en fazla 20 karakter");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("en az 3 karakter");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("en fazla 20 karakter");
           
        }
    }
}
