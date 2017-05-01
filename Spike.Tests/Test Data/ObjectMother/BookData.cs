
namespace Spike.Tests.Test_Data.ObjectMother
{
    using Adapters.Books;
    using Contracts.Books;
    using StubData.Builders;

    public class BookData
    {
        public void Initalize()
        {
            var adapter = new BookAdapter();

            FiveDysfunctions = adapter.AddBook(new BookBuilder().FiveDysfunctions().Build());
            PhoenixProject = adapter.AddBook(new BookBuilder().ThePhoenixProject().Build());

            adapter.SaveChanges();
        }

        public Book FiveDysfunctions { get; set; }

        public Book PhoenixProject { get; set; }
    }
}
