using NHibernate;

namespace DataAccess.NHibernate
{
    public interface ISessionProvider
    {
        ISession GetCurrentSession();
    }
}
