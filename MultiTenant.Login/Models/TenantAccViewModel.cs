namespace MultiTenant.Login.Models
{
    public class TenantAccViewModel
    {
        public int TenantId { get; set; }
        public int AccId { get; set; }
        public string UserName { get; set; }
        public string DbName { get; set; }
      
    }
}
