using Microsoft.EntityFrameworkCore;
using MultiTenant.Data.Entities_Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Data.Contexts
{
    public class MultiTenantContext : DbContext
    {

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public MultiTenantContext()
        {

        }
        public MultiTenantContext(DbContextOptions<MultiTenantContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=HUYDESKTOP;Database=MultiTenant;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId);
                entity.HasOne<Tenant>(s => s.Tenant)
                      .WithMany(g => g.Accounts)
                      .HasForeignKey(s => s.TenantId);
                entity.Property(p => p.Email).IsRequired();
                entity.Property(p => p.Password).IsRequired();

            });
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.TenantId);
            });
        }

    }
}
