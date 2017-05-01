
using System.Configuration;
using System.Security.Authentication;

namespace Spike.Tests.RollbackTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Transactions;
    using DataSource;

    [TestClass]
    public class TransactionBase
    {
        private static bool _isInitialized;
        private TransactionScope _scope;

        public void InitializeGlobal()
        {
            if (_isInitialized) return;
            
            if (!Utilities.UsingLocalDatabase())
            {
                throw new AuthenticationException("You can only delete and recreate local databases when doing Unit Testing.");
            }

            var context = new DataContext();
            context.Database.Delete();
            context.Database.CreateIfNotExists();

            _isInitialized = true;
        }

        [TestInitialize]
        public void TestInitialization()
        {
            InitializeGlobal();

            this._scope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        [TestCleanup]
        public void TestComplete()
        {
            this._scope.Dispose();
        }
    }
}
