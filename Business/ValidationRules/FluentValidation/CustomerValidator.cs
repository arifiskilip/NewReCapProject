using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.UserId).NotNull();
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.ComponyName).NotEmpty();
            RuleFor(c => c.ComponyName).NotNull();
            RuleFor(c => c.ComponyName).MinimumLength(3);
            RuleFor(c => c.ComponyName).MaximumLength(50);
        }
    }
}
