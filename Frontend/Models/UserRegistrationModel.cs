

using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Frontend.Models
{
    public class UserRegistrationModel
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public MailAddress Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}