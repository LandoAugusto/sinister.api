using Infrastruture.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastruture.CrossCutting.Identity
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }
        public string? GetUserEmail()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : String.Empty;
        }

        public string? GetUserName()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserName() : String.Empty;
        }

        public int? GetExternalId()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetExtenalID() : null;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst("userId");
            if (claim == null) return null;
            return claim?.Value;
        }

        public static string? GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst(ClaimTypes.Email);
            if (claim == null) return null;
            return claim.Value;
        }

        public static string? GetUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst("userName");
            if (claim == null) return null;
            return claim.Value;
        }

        public static int? GetExtenalID(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst("extID");
            if (claim == null) return null;
            return int.Parse(claim.Value);
        }
    }
}
