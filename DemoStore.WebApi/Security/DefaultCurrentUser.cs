using DemoStore.WebApi;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace DemoStore.WebApi
{
    internal class DefaultCurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;

        public DefaultCurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool IsAuthenticated => this.User.Identity?.IsAuthenticated ?? false;

        public ClaimsPrincipal User => _accessor.HttpContext?.User ?? new ClaimsPrincipal();

        public string GetUserId()
        {
            return this.User.Identity?.Name ?? String.Empty;
        }

        public string GetTenantId()
        {
            return this.User.FindFirstValue("TenantId") ?? String.Empty;
        }

        public string? GetClaim(string type)
        {
            return this.User.FindFirstValue(type);
        }

        public bool HasClaim(string type, string? value)
        {
            if (value is not null)
            {
                return this.User.HasClaim(type, value);
            }
            else
            {
                return this.User.HasClaim(x => x.Type == type);
            }
        }

        public bool IsInRole(string role)
        {
            return this.User.IsInRole(role);
        }
    }
}
