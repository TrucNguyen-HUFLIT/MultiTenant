using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Models.AccTenants;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.MultiTenants.AccTenants
{
    public class AccTenantService : IAccTenantService
    {
        private readonly MultiTenantContext _context;

        public AccTenantService(MultiTenantContext context)
        {
            //  _tenantcontext = tenantcontext;
            _context = context;
        }

        public async Task<bool> Delete(AccTenantRequest accTenantRequest)
        {

            var detailacc = await _context.AccountTenants.Where(x => x.AccId == accTenantRequest.AccId & x.TenantId == accTenantRequest.TenantId ).FirstOrDefaultAsync();

            _context.Remove(detailacc);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Tenant>> GetListTenantOfAccountAsync(int id)
        {

            var listTenantId = _context.AccountTenants.Where(x => x.AccId == id).Select(x => x.TenantId).ToList();

            var listTenant = new List<Tenant>();
            foreach (var TenantId in listTenantId)
            {
                //var tn = await _context.Tenants.Where(x => x.TenantId == TenantId).FirstOrDefaultAsync();
                listTenant.Add(await _context.Tenants.Where(x => x.TenantId == TenantId).FirstOrDefaultAsync());
            }

            return listTenant;
        }

        public async Task<List<string>> GetListTenantByUserName(string username)
        {
            int accId = await _context.Accounts.Where(x => x.UserName == username).Select(x => x.AccId).FirstOrDefaultAsync();
            var listTenantId = _context.AccountTenants.Where(x => x.AccId == accId).Select(x => x.TenantId).ToList();

            var listTenant = new List<string>();
            foreach (var TenantId in listTenantId)
            {
                //var tn = await _context.Tenants.Where(x => x.TenantId == TenantId).FirstOrDefaultAsync();
                listTenant.Add(await _context.Tenants.Where(x => x.TenantId == TenantId).Select(x=>x.DbName).FirstOrDefaultAsync());
            }

            return listTenant;
        }

        public async Task<AccTenantRequest> GetAccID(int id)
        {

            var model = _context.Accounts.Where(x => x.AccId == id).FirstOrDefault();

            var accTenantRequest = new AccTenantRequest()
            {
                AccId = model.AccId,
                NameAcc=model.Name,
                UserName=model.UserName,
            };

            return accTenantRequest;

        }

        public async Task<List<Tenant>> GetAllListTenant(int id)
        {
            var listTenant= await GetListTenantOfAccountAsync(id);

            var model = await _context.Tenants.ToListAsync();

            foreach (var Tenant in listTenant)
            {
                model.Remove(Tenant);
            }

            return model;

        }

        public async Task AddTenantToAcc(AccTenantRequest accTenantRequest)
        {
           // var tenantId = await _context.AccountTenants.Where(x => x.TenantId == accTenantRequest.TenantId).FirstOrDefaultAsync();

            var model = new AccountTenant()
            {
                AccId=accTenantRequest.AccId,
                TenantId=accTenantRequest.TenantId,
            };
            _context.AccountTenants.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<AccTenantRequest> SetDbNameToTenant(AccTenantRequest accTenantRequest)
        {
            accTenantRequest.DbName = await _context.Tenants.Where(x => x.TenantId == accTenantRequest.TenantId).Select(x => x.DbName).FirstOrDefaultAsync();
            return accTenantRequest;
        }
    }
}
