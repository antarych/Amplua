
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using UserManagement.Domain;

namespace Frontend.Authorization
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        private readonly AccountRoles _accountRole;

        public AuthorizationAttribute(AccountRoles accountRole)
        {
            _accountRole = accountRole;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return Thread.CurrentPrincipal.IsInRole(_accountRole);
        }
    }
}