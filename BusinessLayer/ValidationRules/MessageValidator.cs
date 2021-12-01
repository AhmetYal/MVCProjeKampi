using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Boş Bırakamazsın");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Boş Bırakamazsın");
              
            
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("en az 3 karakter");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("en fazla 100 karakter");
            RuleFor(x => x.MessageContent).MinimumLength(3).WithMessage("en az 3 karakter");
            

        }
    }
}
