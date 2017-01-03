using DataAccess;
using DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessTest
{
    [TestClass]
    public class DatabaseSessionProviderTests
    {
        [TestMethod]
        public void CreateSchemaTest()
        {
            var provider = new NHibernateHelper();
            using (var currentSession = provider.GetCurrentSession())
            {
                
            }     
        }
    }
}
