
namespace MultiTenant.Data.Entities_Tenant
{
    public class Account
    {
        public int AccId { get; set; } //Id
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; } //Picture
        public Role Role { get; set; }
        public int TenantId { get; set; } //ClientID
        public Tenant Tenant { get; set; }
    }
    public enum Role
    {
        Admin = 1,
        Customer = 2,
    }
}
