
using Spike.Orchestrations.CustomerOrchestration;

namespace Spike.Tests.RollbackAdapterTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Adapters.Books;
    using StubData.Builders;
    using Adapters.Customers;
    using Adapters.LibraryCards;
    using Waldos;
    using System;
    using Orchestrations.BookOrchestration;
    using StubData.Mocking;

    [TestClass]
    public class DatabaseAdapterTests : TransactionBase
    {
        [TestMethod]
        public void AdapterAddBookTest()
        {
            var expected = new BookBuilder().FiveDysfunctions().Build();
            var adapter = new BookAdapter();

            var response = adapter.AddBook(expected);

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(expected, response);
            Assert.IsTrue(comparison.AreEqual, $"Expected [{expected}] Actual [{response}]");
        }

        [TestMethod]
        public void AdapterAddCustomerTest()
        {
            var expected = new CustomerBuilder().JohnDoe().Build();
            var adapter = new CustomerAdapter();

            var response = adapter.AddCustomer(expected);

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(expected, response);
            Assert.IsTrue(comparison.AreEqual, $"Expected [{expected}] Actual [{response}]");
        }

        [TestMethod]
        public void AdapterAddLibraryCardTest()
        {
            var customer = CustomerWaldo.PrepareJohnDoeCustomer();

            var expected = new LibraryCardBuilder().JohnDoeCard(customer).Build();
            var adapter = new LibraryCardAdapter();

            var response = adapter.AddLibraryCard(expected);

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(expected, response);
            Assert.IsTrue(comparison.AreEqual, $"Expected [{expected}] Actual [{response}]");
        }

        [TestMethod]
        public void AdapterGetBookByIdTest()
        {
            var mockedAdapter = new BookAdapterMocks().MockGetBook().Build();

            var orch = new BookOrchestrator(mockedAdapter);
            var response = orch.GetBookById(Guid.NewGuid());

            var expected = new BookBuilder(response.Id).FiveDysfunctions().Build();

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(expected, response);
            Assert.IsTrue(comparison.AreEqual, $"Expected [{expected}] Actual [{response}]");
        }

        [TestMethod]
        public void AdapterGetCustomerByIdTest()
        {
            var mockedAdapter = new CustomerAdapterMocks().MockGetCustomer().Build();

            var orch = new CustomerOrchestrator(mockedAdapter);
            var response = orch.GetCustomerById(Guid.NewGuid());

            var expected = new CustomerBuilder(response.Id).JohnDoe().Build();

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(expected, response);
            Assert.IsTrue(comparison.AreEqual, $"Expected [{expected}] Actual [{response}]");
        }
    }
}
