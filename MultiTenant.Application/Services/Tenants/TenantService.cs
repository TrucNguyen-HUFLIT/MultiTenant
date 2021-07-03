using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Models.Tenants;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.Tenants
{
    public class TenantService : ITenantService
    {
        private readonly MultiTenantContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public TenantService(MultiTenantContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }
        public async Task<PagingList<Tenant>> GetListTenantsAsync(string filter, int page, string sortEx = "TenantId")
        {
            var qry = _context.Tenants.AsNoTracking().OrderBy(p => p.DbName).AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(p => p.DbName.StartsWith(filter));
            }

            var model = await PagingList.CreateAsync(qry, 10, page, sortEx, "TenantId");
            model.RouteValue = new RouteValueDictionary {
            { "filter", filter}
            };

            return model;
        }

        public async Task<TenantEdit> GetTenantEditByIdAsync(int id)
        {
            var model = await _context.Tenants
                 .Where(x => x.TenantId == id)
                 .Select(x => new { x.TenantId, x.DbName, x.SubDomain,x.Favicon })
                 .FirstOrDefaultAsync();
            if (model != null)
            {
                var tenantEdit = new TenantEdit
                {

                    TenantId = model.TenantId,
                    DbName=model.DbName,
                    SubDomain=model.SubDomain,
                    Favicon=model.Favicon
                };
                return tenantEdit;
            }
            return null;
        }
    }
}
