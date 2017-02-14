using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Common;
using Journalist;
using UserManagement.Application;
using UserManagement.Infrastructure;

namespace UserManagement.Domain
{
    public class Authorizer : IAuthorizer
    {        
        public Authorizer(TimeSpan tokenLifeTime, IUserRepository userRepository)
        {
            TokenLifeTime = tokenLifeTime;
            _userRepository = userRepository;
        }

        private readonly IUserRepository _userRepository;

        public TimeSpan TokenLifeTime { get; }

        private readonly ConcurrentDictionary<string, AuthorizationTokenInfo> _tokensWithGenerationTime
            = new ConcurrentDictionary<string, AuthorizationTokenInfo>();

        public AuthorizationTokenInfo GetTokenInfo(string authorizationToken)
        {
            Require.NotEmpty(authorizationToken, nameof(authorizationToken));

            if (!_tokensWithGenerationTime.ContainsKey(authorizationToken))
            {
                return null;
            }

            var token = _tokensWithGenerationTime[authorizationToken];

            if (token.CreationTime + TokenLifeTime < DateTime.Now)
            {
                _tokensWithGenerationTime.TryRemove(token.Token, out token);
                return null;
            }

            token.CreationTime = DateTime.Now;
            return token;
        }

        public AuthorizationTokenInfo Authorize(string mail, Password password)
        {
            Require.NotNull(password, nameof(password));

            var userAccounts = _userRepository
                .GetAllAccounts(account => account.Email.Address == mail &&
                                           account.ConfirmationStatus == ConfirmationStatus.MailConfirmed).Single();
            if (userAccounts == null)
            {
                throw new UnauthorizedAccessException("Account not found");
            }
            if (userAccounts.Password.Value != password.Value)
            {
                throw new UnauthorizedAccessException("Incorrect password");
            }

            var userToken = GetTokenByUserId(userAccounts.UserId);
            if (userToken == null)
            {
                userToken = GenerateNewToken(userAccounts);
                _tokensWithGenerationTime.AddOrUpdate(userToken.Token, userToken, (oldToken, info) => userToken);
            }
            return userToken;
        }

        private AuthorizationTokenInfo GetTokenByUserId(int userId)
        {
            var tokenById = _tokensWithGenerationTime.SingleOrDefault(token => token.Value.UserId == userId);
            if (!tokenById.Equals(default(KeyValuePair<string, AuthorizationTokenInfo>)))
            {
                return tokenById.Value;
            }

            return null;
        }

        private static AuthorizationTokenInfo GenerateNewToken(Account account)
        {
            var guid = Guid.NewGuid();
            var token = BitConverter.ToString(guid.ToByteArray());
            token = token.Replace("-", "");
            return new AuthorizationTokenInfo(account.UserId, account.Role, token, DateTime.Now);
        }
    }
}
