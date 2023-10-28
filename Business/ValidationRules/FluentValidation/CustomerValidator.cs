using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(C => C.FirstName).NotEmpty();
            RuleFor(c => c.FirstName).MinimumLength(3);
        }
    }
}
