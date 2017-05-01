
namespace Spike.StubData.Adapters
{
    using System;
    using Contracts;
    using Contracts.Books;
    using Mocking;

    public class BookAdapter : IBookAdapter
    {
        public Book AddBook(Book book)
        {
            var mocker = new BookAdapterMocks().MockAddBook().Build();
            return mocker.AddBook(book);
        }

        public Book GetBook(Guid id)
        {
            var mocker = new BookAdapterMocks().MockGetBook().Build();
            return mocker.GetBook(id);
        }

        public Book UpdateBook(Guid id, IBookEditable book)
        {
            var mocker = new BookAdapterMocks().MockUpdateBook().Build();
            return mocker.UpdateBook(id, book);
        }

        public PagedResult<Book> Search(SearchFilters filters, PageArgs pageArgs)
        {
            var mocker = new BookAdapterMocks().MockSearch().Build();
            return mocker.Search(filters, pageArgs);
        }
    }
}
