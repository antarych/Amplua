using System;
using System.Collections.Generic;
using Common;
using UserManagement.Application;
using UserManagement.Infrastructure;
using Journalist;

namespace UserManagement.Domain
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            Require.NotNull(userRepository, nameof(userRepository));
            _userRepository = userRepository;
        }

        public void CreateUser(CreateAccountRequest request)
        {
            Require.NotNull(request, nameof(request));

            var newAccount = new Account(
                request.Firstname,
                request.Lastname,
                request.Email,
                Password.FromPlainString(request.Password),
                DateTime.Now,
                AccountRoles.User, 
                ConfirmationStatus.NotConfirmed);
            var userId = _userRepository.CreateAccount(newAccount);
        }

        public Account GetUser(int userId)
        {
            Require.Positive(userId, nameof(userId));

            var account = _userRepository.GetAccount(userId);

            return account;
        }

        public IEnumerable<Account> GetAccounts(Func<Account, bool> predicate = null)
        {
            return _userRepository.GetAllAccounts(predicate);
        }
    }
}
