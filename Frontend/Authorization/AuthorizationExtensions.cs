
using System.Security.Principal;
using UserManagement.Domain;

namespace Frontend.Authorization
{
    public static class AuthorizationExtensions
    {
        public static bool IsInRole(this IPrincipal principal, AccountRoles role)
        {
            var lodPrincipal = principal as AmpluaPrincipal;
            return lodPrincipal?.IsInRole(role) ?? false;
        }
    }
}