using FluentValidation;
using MultiTenant.Application.Models.MultiTenants.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Validators.Tenant
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
