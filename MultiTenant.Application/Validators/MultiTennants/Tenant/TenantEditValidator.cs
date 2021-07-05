using FluentValidation;
using MultiTenant.Application.Models.MultiTenants.Tenants;

namespace MultiTenant.Application.Validators.MultiTenants.Tenant
{
    public class TenantEditValidator:AbstractValidator<TenantEdit>
    {
        public TenantEditValidator()
        {
            RuleFor(tenant => tenant.TenantId).NotEmpty();
            RuleFor(tenant => tenant.URL).NotEmpty();
            RuleFor(tenant => tenant.DbName).NotEmpty();

        }
    }
}
