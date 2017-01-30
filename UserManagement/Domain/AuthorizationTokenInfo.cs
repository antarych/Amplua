
using System;
using Journalist;

namespace UserManagement.Domain
{
    public class AuthorizationTokenInfo
    {
        public AuthorizationTokenInfo(int userId, AccountRoles role, string token, DateTime creationTime)
        {
            Require.Positive(userId, nameof(userId));
            Require.NotNull(token, nameof(token));

            UserId = userId;
            Role = role;
            Token = token;
            CreationTime = creationTime;
        }

        public int UserId { get; private set; }

        public AccountRoles Role { get; private set; }

        public string Token { get; private set; }

        public DateTime CreationTime { get; set; }
    }
}
