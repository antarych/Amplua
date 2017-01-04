using DataAccess.Mappings.Application;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using UserManagement.Domain;

namespace DataAccess.Mappings
{
    class UserMap : ClassMapping<Account>
    {
        public UserMap()
        {
            Table("Accounts");
            Id(user => user.UserId, mapper => mapper.Generator(Generators.Identity));
            Property(user => user.Firstname, mapper => mapper.Column("Firstname"));
            Property(user => user.Lastname, mapper => mapper.Column("Lastname"));            
            Property(user => user.Email, mapper =>
            {
                mapper.Column("Email");
                mapper.Unique(true);
            });
            Property(user => user.Password, mapper =>
            {
                mapper.Column("Password");
                mapper.Type<PasswordType>();
            });
            Component(x => x.Profile, m =>
            {
                m.Property(profile => profile.AboutUser, mapper => mapper.Column("AboutUser"));
                m.Property(profile => profile.Contacts, mapper => mapper.Column("Contacts"));
                m.Property(profile => profile.Institute, mapper => mapper.Column("Institute"));
            });
            Property(user => user.RegistrationTime, mapper => mapper.Column("RegistrationDate"));
        }
    }
}
