using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Application.Exceptions;
using MultiTenant.Application.Models.MultiTenants.Tenants;
using MultiTenant.Data.Contexts;
using MultiTenant.Data.EntitiesTenant.MultiTenants;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MultiTenant.Application.Services.MultiTenants.Tenants
{
    public class TenantService : ITenantService
    {
        private readonly MultiTenantContext _context;
       // private readonly TenantContext _tenantcontext;
        private readonly IWebHostEnvironment hostEnvironment;

        public TenantService(MultiTenantContext context, IWebHostEnvironment hostEnvironment /*TenantContext tenantcontext*/)
        {
          //  _tenantcontext = tenantcontext;
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task CreateAsync(TenantCreate tenantCreate)
        {
            var dbName = _context.Tenants.Where(x => x.TenantId == tenantCreate.TenantId).Select(x => x.DbName).FirstOrDefault();
            if (dbName != null)
            {
                throw new SameDbExceptions(dbName);
            }

            var model = new Tenant
            {
                DbName = tenantCreate.DbName,
                URL = "https://" + tenantCreate.DbName + ".localhost:5002",
            };

            string wwwrootpath = hostEnvironment.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(tenantCreate.UploadFavicon.FileName);
            string extension = Path.GetExtension(tenantCreate.UploadFavicon.FileName);
            filename += extension;
            string path1 = Path.Combine(wwwrootpath + "/img/", filename);

            using (var filestream = new FileStream(path1, FileMode.Create))
            {
                await tenantCreate.UploadFavicon.CopyToAsync(filestream);
            }
            model.Favicon = "/img/" + filename+extension;

          //  var dbmigrate =  _tenantcontext.Database.MigrateAsync();
            _context.Add(model);
            await _context.SaveChangesAsync();
            
        }

        public async Task<bool> EditAsync(TenantEdit tenantEdit)
        {
            var model = await _context.Tenants.Where(x => x.TenantId == tenantEdit.TenantId).FirstOrDefaultAsync();
            var dbName = await _context.Tenants.Select(x => x.DbName).ToListAsync();

            model.TenantId = tenantEdit.TenantId;
            model.URL = tenantEdit.URL;
            model.DbName = tenantEdit.DbName;

            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName1;
            string extension1;
            if (tenantEdit.UploadFavicon != null)
            {
                fileName1 = Path.GetFileNameWithoutExtension(tenantEdit.UploadFavicon.FileName);
                extension1 = Path.GetExtension(tenantEdit.UploadFavicon.FileName);
                fileName1 += extension1;
                string path1 = Path.Combine(wwwRootPath + "/img/", fileName1);
                using (var fileStream = new FileStream(path1, FileMode.Create))
                {
                    await tenantEdit.UploadFavicon.CopyToAsync(fileStream);
                }
                model.Favicon = "/img/" + fileName1;
            }
            _context.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<X.PagedList.IPagedList<TenantRequest>> GetListTenantRequestAsync(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var model = new List<TenantRequest>();
            var listTenant = await _context.Tenants.ToListAsync();

            if (listTenant != null)
            {

                foreach (var tenant in listTenant)
                {
                    var accountRequest = new TenantRequest
                    {
                        DbName = tenant.DbName,
                        URL = tenant.URL,
                        Favicon = tenant.Favicon,
                        TenantId = tenant.TenantId

                    };
                    model.Add(accountRequest);
                }

                if (!String.IsNullOrEmpty(searchString))
                {
                    model = model.Where(s => s.DbName.Contains(searchString)
                                            || s.DbName.Contains(searchString)).ToList();
                }
                model = sortOrder switch
                {
                    "name_desc" => model.OrderByDescending(x => x.DbName).ToList(),
                    "name" => model.OrderBy(x => x.DbName).ToList(),
                    "id_desc" => model.OrderByDescending(x => x.TenantId).ToList(),
                    _ => model.OrderBy(x => x.TenantId).ToList(),
                };
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return model.ToPagedList(pageNumber, pageSize);

            }

            return null;
        }

        public async Task<TenantEdit> GetTenantEditByIdAsync(int id)
        {
            var model = await _context.Tenants
                 .Where(x => x.TenantId == id)
                 .Select(x => new { x.TenantId, x.DbName, x.URL, x.Favicon })
                 .FirstOrDefaultAsync();
            if (model != null)
            {
                var tenantEdit = new TenantEdit
                {

                    TenantId = model.TenantId,
                    DbName = model.DbName,
                    URL = model.URL,
                    Favicon = model.Favicon
                };
                return tenantEdit;
            }

            return null;

        }
    }
}
