using Microsoft.AspNetCore.Http;
using System;

namespace MultiTenant.Application.Services.Host
{
    class TenantHttpContextAccessor : IHttpContextAccessor
    {
        public HttpContext HttpContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
