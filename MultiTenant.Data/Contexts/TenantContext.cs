using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Data.EntitiesTenant.Tenants;
using System;

namespace MultiTenant.Data.Contexts
{
    public class TenantContext :DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DbSet<Account> Accounts { get; set; }
        public TenantContext()
        {

        }

        public TenantContext(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //get host name
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            string[] dbName = host.Split(".");
            if (dbName.Length == 1)
                dbName[0] = "Tenant";

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer($@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database={dbName[0]};Trusted_Connection=True;");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Account>(entity =>
           {
               entity.HasKey(e => e.IdAcc);
               entity.Property(p => p.Email).IsRequired();
               entity.Property(p => p.Name).IsRequired();

           });
          
        }
    }
}
