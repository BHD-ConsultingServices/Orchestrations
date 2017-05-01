
namespace Spike.Contracts.Books
{
    using System;

    public interface IBookAdapter
    {
        Book AddBook(Book book);

        Book GetBook(Guid id);

        Book UpdateBook(Guid id, IBookEditable book);

        PagedResult<Book> Search(SearchFilters filters, PageArgs pageArgs);
    }
}
