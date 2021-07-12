using FluentValidation;
using MultiTenant.Application.Models.MultiTenants.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Validators.MultiTennants.User
{

    public class AccountCreateValidator : AbstractValidator<AccountCreate>
    {
        public AccountCreateValidator()
        {
            RuleFor(actor => actor.Name).NotEmpty();
            RuleFor(actor => actor.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(actor => actor.UserName).NotEmpty();

        }
    }
}
