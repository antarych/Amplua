using System;
using UserManagement.Application;
using UserManagement.Infrastructure;
using Journalist;
using NHibernate;

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
                request.Password,
                DateTime.Now);
            var userId = _userRepository.CreateAccount(newAccount);
        }

        public Account GetUser(int userId)
        {
            Require.Positive(userId, nameof(userId));

            var account = _userRepository.GetAccount(userId);

            return account;
        }
    }
}
