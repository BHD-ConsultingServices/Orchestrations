
namespace Spike.Tests.MockedTests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Contracts.Books;
    using StubData.Builders;
    using StubData.Mocking;

    [TestClass]
    public class OrchestrationTests
    {
        [TestMethod]
        public void TestAddCustomerByMockingAdapterResponse()
        {
            var adapter = new CustomerAdapterMocks().MockAddCustomer().Build();
            var newCustomer = new CustomerBuilder().JohnDoe().Build();

            var repo = new Orchestrations.CustomerOrchestration.CustomerOrchestrator(adapter);
            var result = repo.AddCustomer(newCustomer);

            Assert.IsNotNull(result);
            Assert.AreEqual(newCustomer, result);
        }

        [TestMethod]
        public void TestAddBookByMockingAdapter()
        {
            var adapter = new BookAdapterMocks().MockAddBook().Build();
            var newBook = new BookBuilder().FiveDysfunctions().Build();

            var repo = new Orchestrations.BookOrchestration.BookOrchestrator(adapter);
            var result = repo.AddBook(newBook);

            Assert.IsNotNull(result);
            Assert.AreEqual(newBook, result);
        }

        [TestMethod]
        public void TestSearchBooksByMockingAdapter()
        {
            var adapter = new BookAdapterMocks().MockSearch().Build();
            var filters = new SearchFilters();

            var repo = new Orchestrations.BookOrchestration.BookOrchestrator(adapter);
            var result = repo.Search(filters, null);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.PageData.Any());
        }
    }
}
