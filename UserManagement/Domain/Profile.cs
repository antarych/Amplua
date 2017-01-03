
namespace UserManagement.Domain
{
    public class Profile
    {
        public Profile()
        {
            AboutUser = "about";
            Contacts = "contacts";
            Institute = "institute";
        }

        public virtual string AboutUser { get; set; }

        public virtual string Contacts { get; set; }

        public virtual string Institute { get; set; }
    }
}
