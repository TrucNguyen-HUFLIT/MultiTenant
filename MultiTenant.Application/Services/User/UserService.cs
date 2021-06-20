using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Models;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.Entities_Tenant;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly MultiTenantContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public UserService(MultiTenantContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        public Task<bool> EditAsync(AccountEdit accountEdit)
        {
            throw new NotImplementedException();
        }

        public AccountEdit GetAccountEditById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagingList<Account>> GetListUsersAsync(string filter, int page, string sortEx = "AccId")
        {

            var qry = _context.Accounts.AsNoTracking().OrderBy(p => p.FirstName).AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(p => p.FirstName.StartsWith(filter));
            }

            var model = await PagingList.CreateAsync(qry, 10, page, sortEx, "FirstName");

            model.RouteValue = new RouteValueDictionary {
            { "filter", filter}
            };

            return model;
        }
    }
}
