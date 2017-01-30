using System;
using Common;
using Journalist;
using System.Net.Mail;

namespace UserManagement.Domain
{
    public class Account
    {
        public Account(string firstname,
            string lastname,
            MailAddress email,
            Password password,
            DateTime registrationTime,
            AccountRoles role,
            ConfirmationStatus confirmationStatus)
        {
            Require.NotEmpty(firstname, nameof(firstname));
            Require.NotEmpty(lastname, nameof(lastname));
            Require.NotNull(email, nameof(email));
            Require.NotNull(password, nameof(password));

            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            RegistrationTime = registrationTime;
            Profile = new Profile();
            Role = role;
            ConfirmationStatus = confirmationStatus;
        }

        protected Account()
        {
        }

        public virtual int UserId { get; protected set; }

        public virtual string Firstname { get; protected set; }

        public virtual string Lastname { get; protected set; }

        public virtual MailAddress Email { get; protected set; }

        public virtual Password Password { get; set; }

        public virtual DateTime RegistrationTime { get; protected set; }

        public virtual Profile Profile { get; set; }

        public virtual AccountRoles Role { get; set; }

        public virtual ConfirmationStatus ConfirmationStatus { get; set; }
    }
}
