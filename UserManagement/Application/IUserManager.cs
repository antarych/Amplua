using UserManagement.Domain;

namespace UserManagement.Application
{
    public interface IUserManager
    {
        Account GetUser(int userId);

        void CreateUser(CreateAccountRequest request);
    }
}
