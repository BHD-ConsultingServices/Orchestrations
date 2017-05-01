
namespace Spike.Contracts.LibraryCards
{
    using System.Collections.Generic;
    using Books;
    using Customers;

    public class LibraryCardBase : ILibraryCardEditable
    {
        public Customer Customer { get; set; }
        
        public IEnumerable<Book> RentedBooks { get; set; }
    }
}
