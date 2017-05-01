
namespace Spike.Tests.RollbackTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StubData.Builders;
    using Adapters.Books;

    [TestClass]
    public class DatabaseAdapterTests : TransactionBase
    {
        [TestMethod]
        public void TestAddBook()
        {
            var newBook = new BookBuilder().FiveDysfunctions().Build();
            var adapter = new BookAdapter();

            var response = adapter.AddBook(newBook);

            Assert.IsNotNull(response);
            var comparison = Utilities.CompareObjects(newBook, response);
            Assert.IsTrue(comparison.AreEqual, $"Expected [{newBook}] Actual [{response}]");
        }
    }
}
