

namespace Spike.Adapters.Books
{
    using System;
    using System.Linq;
    using Mappings;
    using Contracts;
    using Contracts.Books;
    using DataSource.Entities;

    public class BookAdapter : AdapterBase, IBookAdapter
    {
        public Book AddBook(Book book)
        {
            var result = Context.Books.Add(book.Map<BookEntity, Book>());
            return result.Map<Book, BookEntity>();
        }

        public Book GetBook(Guid id)
        {
            var result = Context.Books.Single(b => b.Id == id);
            return result.Map<Book, BookEntity>();
        }

        public Book UpdateBook(Guid id, IBookEditable book)
        {
            var current = Context.Books.Single(b => b.Id == id);

            current.Author = book.Author;
            current.ReleaseDate = book.ReleaseDate;

            return current.Map<Book, BookEntity>();
        }

        public PagedResult<Book> Search(SearchFilters filters, PageArgs pageArgs)
        {
            var query = new BookQuery(Context.Books);
            return query.Search(filters, pageArgs);
        }
    }
}
