using FluentValidation;
using MultiTenant.Application.Models.Tenants.Account;

namespace MultiTenant.Application.Validators.Tenants
{
    public class AccountEditValidator : AbstractValidator<AccountEdit>
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