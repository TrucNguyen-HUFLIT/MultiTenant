using FluentValidation;
using MultiTenant.Application.Models;

namespace MultiTenant.Application.Validators.User
{
    public  class AccountEditValidator: AbstractValidator<AccountEdit>
    {
        public AccountEditValidator()
        {
            RuleFor(actor => actor.Name).NotEmpty();
            RuleFor(actor => actor.AccId).NotEmpty();
            RuleFor(actor => actor.Email).NotEmpty();
          
        }
    }
}
