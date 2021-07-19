using FluentValidation;
using MultiTenant.Application.Models.MultiTenants.Tenants;

namespace MultiTenant.Application.Validators.MultiTennants.Tenant
{
    public class TenantCreateValidator:AbstractValidator<TenantCreate>
    {
        public TenantCreateValidator()
        {
            //RuleFor(tenant => tenant.Favicon).NotEmpty();
            RuleFor(tenant => tenant.DbName).NotEmpty();

        }
    }
}
