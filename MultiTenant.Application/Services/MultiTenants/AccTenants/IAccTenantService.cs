using MultiTenant.Application.Models.AccTenants;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.MultiTenants.AccTenants
{
    public interface IAccTenantService
    {
        Task<AccTenantRequest> GetAccID(int id);
        Task<List<Tenant>> GetAllListTenant(int id);
        Task AddTenantToAcc(AccTenantRequest accTenantRequest);

        Task<bool> Delete(AccTenantDelete accTenantDelete);
        Task <List<Tenant>> GetListTenantOfAccountAsync(int id);
        Task<List<string>> GetListTenantByUserName(string username);
        Task<AccTenantRequest> SetDbNameToTenant(AccTenantRequest accTenantRequest);
    }
}
