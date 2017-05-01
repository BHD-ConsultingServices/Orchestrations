
namespace Spike.Contracts.Books
{
    using System;

    public interface IBookOrchestrator
    {
        Book AddBook(BookBase request);

        Book GetBookById(Guid id);

        Book EditBook(Guid id, IBookEditable book);

        PagedResult<Book> Search(SearchFilters filters, PageArgs pageArgs);
    }
}
