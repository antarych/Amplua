using System.Net.Mail;
using UserManagement.Domain;


namespace Frontend.Models
{
    public class UserPresentationModel
    {
        public UserPresentationModel(string firstname, string lastname, MailAddress email, Profile profile)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Profile = profile;
        }
               
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public MailAddress Email { get; set; }

        public virtual Profile Profile { get; set; }
    }
}