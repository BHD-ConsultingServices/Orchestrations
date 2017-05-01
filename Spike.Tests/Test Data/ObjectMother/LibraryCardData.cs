
namespace Spike.Tests.Test_Data.ObjectMother
{
    using System.Collections.Generic;
    using Adapters.LibraryCards;
    using Contracts.Books;
    using Contracts.LibraryCards;
    using StubData.Builders;

    public class LibraryCardData
    {
        public void Initalize()
        {
            var adapter = new LibraryCardAdapter();

            JaneDoeCard = adapter.AddLibraryCard(new LibraryCardBuilder().JaneDoeCard(
                ObjectMother.Instance.Customers.JaneDoe).Build());
            JhonDoeCard = adapter.AddLibraryCard(new LibraryCardBuilder().JohnDoeCard(
                ObjectMother.Instance.Customers.JohnDoe).Build());

            adapter.SaveChanges();
        }

        public LibraryCard JaneDoeCard { get; set; }

        public LibraryCard JhonDoeCard { get; set; }

    }
}
