using Microsoft.EntityFrameworkCore;
using MultiTenant.Data.EntitiesTenant.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Data.Contexts
{
    public class TenantContext :DbContext
    {
        //public DbSet<Account> Accounts { get; set; }
        //public TenantContext()
        //{

        //}
        //public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        //{

        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer(@"Server=HUYDESKTOP;Database=Tenant;Trusted_Connection=True;");

        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Account>(entity =>
        //    {
        //        entity.HasKey(e => e.IdAcc);
        //        entity.Property(p => p.Email).IsRequired();
        //        entity.Property(p => p.Name).IsRequired();

        //    });
          
        //}
    }
}
