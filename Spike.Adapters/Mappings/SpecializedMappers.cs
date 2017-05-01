
namespace Spike.Adapters.Mappings
{
    using Contracts.Customers;
    using Contracts.LibraryCards;
    using DataSource.Entities;
    using System.Linq;
    using Contracts.Books;

    public static class SpecializedMappers
    {
        public static LibraryCard Map(this LibraryCardEntity original)
        {
            return new LibraryCard
            {
                Id = original.Id,
                Customer = original.Customer.Map<Customer, CustomerEntity>()
            };
        }

        public static LibraryCardEntity Map(this LibraryCard original)
        {
            return new LibraryCardEntity
            {
                Id = original.Id,
                CustomerId = original.Customer.Id
            };
        }

        public static CustomerEntity Map(this Customer original)
        {
            return new CustomerEntity
            {
                Id = original.Id,
                Name = original.Name,
                PhoneNumber = original.PhoneNumber,
                Adress = original.Adress,
                IdentityNumer = original.IdentityNumer,
                RentedBooks = original.RentedBooks?.MapAll<BookEntity, Book>().ToList()
            };
        }

        public static Customer Map(this CustomerEntity original)
        {
            return new Customer
            {
                Id = original.Id,
                Name = original.Name,
                PhoneNumber = original.PhoneNumber,
                Adress = original.Adress,
                IdentityNumer = original.IdentityNumer,
                RentedBooks = original.RentedBooks?.MapAll<Book, BookEntity>().ToList()
            };
        }
    }
}
