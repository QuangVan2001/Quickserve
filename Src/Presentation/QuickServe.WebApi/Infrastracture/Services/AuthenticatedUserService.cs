using Microsoft.AspNetCore.Http;
using QuickServe.Application.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace QuickServe.WebApi.Infrastracture.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            UserName = httpContextAccessor.HttpContext?.User?.Identity.Name;
            Roles = httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role).Select(x => x.Value).ToArray();
        }

        public string UserId { get; }
        public string UserName { get; }
        public string[] Roles { get; }
    }
}
