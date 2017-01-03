using DataAccess.NHibernate;
using Journalist;
using UserManagement.Infrastructure;
using UserManagement.Domain;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISessionProvider _sessionProvider;

        public UserRepository(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public int CreateAccount(Account account)
        {
            Require.NotNull(account, nameof(account));

            var session = _sessionProvider.GetCurrentSession();
            var savedAccountId = (int)session.Save(account);
            return savedAccountId;
        }

        public Account GetAccount(int accountId)
        {
            Require.Positive(accountId, nameof(accountId));

            var session = _sessionProvider.GetCurrentSession();
            var account = session.Get<Account>(accountId);
            return account;
        }
    }
}
