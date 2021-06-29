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
            _httpContextAccessor = httpContextAccessor; //chỗ này n chưa được truyền vào nè a.
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string host_dbName = "";
            try
            {
                host_dbName = _httpContextAccessor.HttpContext.Request.Host.Value;
            }
            
            catch(Exception ex)
            {
            }

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer($@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database={host_dbName};Trusted_Connection=True;");

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
