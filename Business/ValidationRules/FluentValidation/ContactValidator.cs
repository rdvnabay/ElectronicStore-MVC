using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty();
            RuleFor(c => c.District).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
        }
    }
}
