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
        Task<List<Tenant>> GetAllListTenant(int id);
        Task AddTenantToAcc(AccTenantRequest accTenantRequest);

        Task<bool> Delete(int tenantId, int accId);
        Task <List<Tenant>> GetListTenantOfAccountAsync(int id);
        Task<List<string>> GetListTenantByUserName(string username);
    }
}
