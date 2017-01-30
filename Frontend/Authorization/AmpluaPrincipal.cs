
using System.Security.Principal;
using Journalist;
using UserManagement.Domain;

namespace Frontend.Authorization
{
    public class AmpluaPrincipal : IPrincipal
    {
        private readonly AccountRoles _accountRole;

        public AmpluaPrincipal(AccountRoles accountRole, IIdentity identity)
        {
            Require.NotNull(identity, nameof(identity));

            _accountRole = accountRole;
            Identity = identity;
        }

        public IIdentity Identity { get; }

        public bool IsEmpty { get; private set; }

        public static IPrincipal EmptyPrincipal
            => new AmpluaPrincipal(AccountRoles.User, AmpluaIdentity.EmptyIdentity) { IsEmpty = true };

        public bool IsInRole(string role)
        {
            return !IsEmpty && _accountRole.ToString("G").Equals(role);
        }

        public bool IsInRole(AccountRoles role)
        {
            return (_accountRole == AccountRoles.Admin || _accountRole == role) && !IsEmpty;
        }
    }
}