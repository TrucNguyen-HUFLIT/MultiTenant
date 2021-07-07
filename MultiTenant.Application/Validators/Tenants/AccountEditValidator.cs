using FluentValidation;
using MultiTenant.Application.Models.Tenants.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Validators.Tenants
{
    class AccountEditValidator : AbstractValidator<AccountEdit>
    {
        public AccountEditValidator()
        {
            RuleFor(actor => actor.Name).NotEmpty();
            RuleFor(actor => actor.Age).NotEmpty();
            RuleFor(actor => actor.Email).NotEmpty();
            RuleFor(actor => actor.IdAcc).NotEmpty();
        }
    }
}
