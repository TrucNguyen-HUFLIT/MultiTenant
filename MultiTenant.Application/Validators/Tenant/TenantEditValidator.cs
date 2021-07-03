﻿using FluentValidation;
using MultiTenant.Application.Models.Tenants;
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
            RuleFor(tenant => tenant.SubDomain).NotEmpty();
            RuleFor(tenant => tenant.DbName).NotEmpty();

        }
    }
}