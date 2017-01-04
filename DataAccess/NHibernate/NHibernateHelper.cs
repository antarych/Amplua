using NHibernate;
using System.Reflection;
using System.Threading;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Web;
using DataAccess.Mappings;

namespace DataAccess
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            var cfg = new Configuration()
            .DataBaseIntegration(db => {
                db.ConnectionString = @"Server=localhost;Database=Amplua;User ID=newuser;Password=password;";
                db.Dialect<MySQL5InnoDBDialect>();
            });
            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);
            new SchemaUpdate(cfg).Execute(true, true);
            var sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
