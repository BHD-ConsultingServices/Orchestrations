
namespace Spike.Tests.IntegrationTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Contracts.Books;
    using Orchestrations.Common;
    using StubData.Builders;
    using Contracts.Customers;
    using Contracts.LibraryCards;

    [TestClass]
    public class OrchestrationTests : TransactionBase
    {
        [TestMethod]
        public void TestAddBookIntegrationTest()
        {
            var orch = DependencyFactory.Resolve<IBookOrchestrator>();

            var response = orch.AddBook(new BookBuilder().FiveDysfunctions().Build());
            var expected = new BookBuilder(response.Id).FiveDysfunctions().Build();

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(expected, response);
            Assert.IsTrue(comparison.AreEqual);
        }

        [TestMethod]
        public void TestAddCustomerIntegrationTest()
        {
            var orch = DependencyFactory.Resolve<ICustomerOrchestrator>();

            var response = orch.AddCustomer(new CustomerBuilder().JohnDoe().Build());
            var expected = new CustomerBuilder(response.Id).JohnDoe().Build();

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(expected, response);
            Assert.IsTrue(comparison.AreEqual);
        }

        [TestMethod]
        public void TestAddLibraryCardIntegrationTest()
        {
            var orch = DependencyFactory.Resolve<ILibraryCardOrchestrator>();

            var response = orch.AddLibraryCard(new LibraryCardBuilder().JohnDoeCard().Build());
            var expected = new LibraryCardBuilder(response.Id).JohnDoeCard(response.Customer).Build();

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(expected, response);
            Assert.IsTrue(comparison.AreEqual);
        }

    }
}
