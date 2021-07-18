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
            RuleFor(actor => actor.Password).MinimumLength(6).MaximumLength(20)
                .Matches(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{6,20}$")
                .WithMessage("Password contains at least 1 uppercase letters, 1 lowercase letters and 1 numbers, and the entire string is longer than 6");
            RuleFor(actor => actor.UserName).NotEmpty();

        }
    }
}
