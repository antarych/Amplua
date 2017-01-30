using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Frontend.Models
{
    public class LoginInformation
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}