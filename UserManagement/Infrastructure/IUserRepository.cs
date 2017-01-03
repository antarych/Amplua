using UserManagement.Domain;

namespace UserManagement.Infrastructure
{
    public interface IUserRepository
    {
        int CreateAccount(Account account);

        Account GetAccount(int accountId);
    }
}
