using System.ComponentModel.DataAnnotations;


namespace Frontend.Models
{
    public class UserRegistrationModel
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}