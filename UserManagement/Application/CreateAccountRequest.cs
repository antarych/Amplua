using UserManagement.Domain;

namespace UserManagement.Application
{
    public class CreateAccountRequest
    {
        public CreateAccountRequest(
            string lastname,
            string firstname,
            string password,
            string email)
        {
            Email = email;
            Lastname = lastname;
            Firstname = firstname;
            Password = password;
        }

        public string Email { get; private set; }

        public string Lastname { get; private set; }

        public string Firstname { get; private set; }

        public string Password { get; private set; }
    }
}
