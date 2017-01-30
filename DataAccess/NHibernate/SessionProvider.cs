using System;
using System.Threading;
using System.Web;
using DataAccess.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace DataAccess.NHibernate
{
    public class SessionProvider : ISessionProvider
    {
        private const string SessionKey = "NHibernateSession";
        private const string TransactionKey = "NHibernateTransaction";
        private readonly ISessionFactory _factory;

        public SessionProvider()
        {
            var configuration = new Configuration();
            configuration.Configure();
            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<UserMap>();
            configuration.AddDeserializedMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities(), null);

            _factory = configuration.BuildSessionFactory();

            new SchemaUpdate(configuration).Execute(false, true);
        }

        private ISession Session
        {
            get
            {
                var session = HttpContext.Current?.Items[SessionKey] as ISession;
                return session
                       ?? Thread.GetData(Thread.GetNamedDataSlot(SessionKey)) as ISession;
            }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items[SessionKey] = value;
                }
                else
                {
                    Thread.SetData(Thread.GetNamedDataSlot(SessionKey), value);
                }
            }
        }

        private ITransaction Transaction
        {
            get
            {
                var transaction = HttpContext.Current?.Items[TransactionKey] as ITransaction;
                return transaction
                       ?? Thread.GetData(Thread.GetNamedDataSlot(TransactionKey)) as ITransaction;
            }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items[TransactionKey] = value;
                }
                else
                {
                    Thread.SetData(Thread.GetNamedDataSlot(TransactionKey), value);
                }
            }
        }

        public ISession GetCurrentSession()
        {
            return Session;
        }

        public void OpenSession()
        {
            if (Session == null || !Session.IsOpen)
            {
                Session = _factory.OpenSession();
            }

            if (!Transaction?.IsActive ?? true)
            {
                Transaction = Session.BeginTransaction();
            }
        }

        public void CloseSession()
        {
            if (Transaction != null && Transaction.IsActive)
            {
                Transaction.Commit();
            }

            Session?.Dispose();
        }

        public void DropSession()
        {
            if (Transaction != null && Transaction.IsActive)
            {
                Transaction.Rollback();
                Transaction.Dispose();
            }

            Session?.Dispose();
        }

        public void ProcessInNHibernateSession(Action action)
        {
            OpenSession();
            action();
            CloseSession();
        }
    }
}
