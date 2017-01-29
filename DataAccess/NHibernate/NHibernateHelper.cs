using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using DataAccess.Mappings;


namespace DataAccess
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            var cfg = new Configuration().Configure();
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
