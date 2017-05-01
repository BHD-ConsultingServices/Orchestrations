
namespace Spike.Orchestrations.BookOrchestration
{
    using System;
    using Contracts;
    using Contracts.Books;
    using Common;

    public class BookOrchestrator : IBookOrchestrator
    {
        private IBookAdapter BookAdapter { get; }

        public BookOrchestrator()
        {
            BookAdapter = DependencyFactory.Resolve<IBookAdapter>();
        } 

        public BookOrchestrator(IBookAdapter bookAdapter)
        {
            BookAdapter = bookAdapter;
        }
        
        public Book AddBook(BookBase book)
        {
            return Worker.AddBook(BookAdapter, book);
        }

        public Book GetBookById(Guid id)
        {
            return BookAdapter.GetBook(id);
        }

        public PagedResult<Book> Search(SearchFilters filters, PageArgs pageArgs)
        {
            return BookAdapter.Search(filters, pageArgs);
        }

        public Book EditBook(Guid id, IBookEditable book)
        {
            return BookAdapter.UpdateBook(id, book);
        }
    }
}
