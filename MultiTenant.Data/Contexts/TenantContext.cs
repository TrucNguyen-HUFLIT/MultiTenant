using Microsoft.EntityFrameworkCore;
using MultiTenant.Data.EntitiesTenant.Tenants;

namespace MultiTenant.Data.Contexts
{
    public class TenantContext :DbContext
    {
        //private readonly string _dbName;
        public DbSet<Account> Accounts { get; set; }
        public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        {

        }
        //public TenantContext(string dbName)
        //{
        //    _dbName = dbName;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer($@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database=tenant;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer($@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database={_dbName};Trusted_Connection=True;");
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
