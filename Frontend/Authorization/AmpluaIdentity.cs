
using System.Security.Principal;

namespace Frontend.Authorization
{
    public class AmpluaIdentity : IIdentity
    {
        public AmpluaIdentity(int userId, bool isAuthenticated)
        {
            UserId = userId;
            IsAuthenticated = isAuthenticated;
        }

        public int UserId { get; }

        public static AmpluaIdentity EmptyIdentity => new AmpluaIdentity(0, false);

        public string Name => UserId.ToString();

        public string AuthenticationType => "Token";

        public bool IsAuthenticated { get; }
    }
}
