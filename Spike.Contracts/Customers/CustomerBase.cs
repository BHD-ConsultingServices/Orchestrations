
namespace Spike.Contracts.Customers
{
    using System.Collections.Generic;
    using Books;

    public class CustomerBase: ICustomerEditable
    {
        public string Name { get; set; }

        public string IdentityNumer { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<Book> RentedBooks { get; set; }
    }
}
