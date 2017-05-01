

namespace Spike.Tests.Test_Data
{
    using System.Linq;
    using Adapters.Customers;
    using Adapters.LibraryCards;
    using StubData.Adapters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ResetWithTestData
    {
        [TestMethod]
        public void ResetAndInitializeTestData()
        {
            ObjectMother.ObjectMother.ClearTestData();
            ObjectMother.ObjectMother.Instance.VerifyInitialization();

            var bookAdapter = new BookAdapter();
            var customerAdapter = new CustomerAdapter();
            var libraryCardAdapter = new LibraryCardAdapter();

            Assert.IsTrue(bookAdapter.Search(new Contracts.Books.SearchFilters(), null).PageData.Any(), "There are no test books");
            Assert.IsTrue(customerAdapter.Search(new Contracts.Customers.SearchFilters(), null).PageData.Any(), "There are no test customers");
            Assert.IsTrue(libraryCardAdapter.Search(new Contracts.LibraryCards.SearchFilters(), null).PageData.Any(), "There are no test library cards");
        }
    }
}
