using FluentValidation;
using MultiTenant.Application.Models.MultiTenants.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
