using Microsoft.EntityFrameworkCore;
using MultiTenant.Data.EntitiesTenant.MultiTenants;

namespace MultiTenant.Data.Contexts
{
    public class MultiTenantContext : DbContext
    {

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTenant> AccountTenants { get; set; }

        public MultiTenantContext()
        {

        }
        public MultiTenantContext(DbContextOptions<MultiTenantContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=HUYDESKTOP;Database=MultiTenant;Trusted_Connection=True;user id=sa1; password=sa123; Integrated Security=false");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTenant>().HasKey(ac => new { ac.AccId, ac.TenantId });

            modelBuilder.Entity<AccountTenant>()
                .HasOne(ac => ac.Account)
                .WithMany(s => s.AccountTenants)
                .HasForeignKey(ac => ac.AccId);

            modelBuilder.Entity<AccountTenant>()
                .HasOne(ac=>ac.Tenant)
                .WithMany(s=>s.AccountTenants)
                .HasForeignKey(ac=>ac.TenantId);



          

        }

    }
}
