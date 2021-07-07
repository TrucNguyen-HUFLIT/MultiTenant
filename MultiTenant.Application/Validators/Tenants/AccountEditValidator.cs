using FluentValidation;
using MultiTenant.Application.Models.Tenants.Account;

namespace MultiTenant.Application.Validators.Tenants
{
    public class AccountEditValidator :AbstractValidator<AccountRequest>
    {
        public AccountEditValidator()
        {
            RuleFor(account => account.IdAcc).NotEmpty();
            RuleFor(account => account.Age).NotEmpty();
            RuleFor(account => account.Email).NotEmpty();
            RuleFor(account => account.Name).NotEmpty();
        }

    }
}
