using NHibernate;

namespace DataAccess.NHibernate
{
    public class SessionProvider : ISessionProvider
    {
        public ISession GetCurrentSession()
        {
            return NHibernateHelper.OpenSession();
        }
    }
}
