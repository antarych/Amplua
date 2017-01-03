using Common;
using Journalist;
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
            Require.NotNull(email, nameof(email));
            Require.NotEmpty(lastname, nameof(lastname));
            Require.NotEmpty(firstname, nameof(firstname));
            Require.NotEmpty(password, nameof(password));

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
