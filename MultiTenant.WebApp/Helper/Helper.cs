using System;
using System.Net.Http;

namespace MultiTenant.WebApp.Helper
{
    public class UserID4API
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5000");
            return client;
        }
    }
}
