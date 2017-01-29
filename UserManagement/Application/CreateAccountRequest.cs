using System.Net.Mail;
using Journalist;


namespace UserManagement.Application
{
    public class CreateAccountRequest
    {
        public CreateAccountRequest(
            string lastname,
            string firstname,
            string password,
            MailAddress email)
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

        public MailAddress Email { get; private set; }

        public string Lastname { get; private set; }

        public string Firstname { get; private set; }

        public string Password { get; private set; }
    }
}
