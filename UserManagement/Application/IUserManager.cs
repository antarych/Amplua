using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UserManagement.Domain;

namespace UserManagement.Application
{
    public interface IUserManager
    {
        Account GetUser(int userId);

        void CreateUser(CreateAccountRequest request);

        IEnumerable<Account> GetAccounts(Func<Account, bool> predicate = null);
    }
}
