
namespace Spike.Orchestrations.BookOrchestration
{
    using System;
    using Contracts.Books;

    public static class Worker
    {
        public static Book AddBook(IBookAdapter adapter, BookBase book)
        {
            var newBook = (Book)book;
            newBook.Id = Guid.NewGuid();

            return adapter.AddBook(newBook);
        }
    }
}
