
namespace Spike.Contracts.LibraryCards
{
    using System.Collections.Generic;
    using Books;
    using Customers;

    public interface ILibraryCardEditable
    {
        Customer Customer { get; set; }

        IEnumerable<Book> RentedBooks { get; set; }
    }
}
