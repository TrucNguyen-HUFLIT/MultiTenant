using MultiTenant.Application.Models.AccTenants;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.MultiTenants.AccTenants
{
    public interface IAccTenantService
    {
        Task<AccTenantRequest> GetAccID(int id);
        List<Tenant> GetAllListTenant();
        Task AddTenantToAcc(AccTenantRequest accTenantRequest);

        Task<bool> Delete(int tenantId, int accId);
        Task <List<Tenant>> GetListTenantOfAccountAsync(int id);
    }
}
