

namespace Spike.Adapters.Mappings
{
    using Contracts.Books;
    using Contracts.Customers;
    using Contracts.LibraryCards;
    using DataSource.Entities;

    public static class UpdateMappers
    {
        public static BookEntity Update(this BookEntity original, IBookEditable update)
        {
            original.Author = update.Author;
            original.ReleaseDate = update.ReleaseDate;

            return original;
        }

        public static CustomerEntity Update(this CustomerEntity original, ICustomerEditable update)
        {
            original.Adress = update.Adress;
            original.PhoneNumber = update.PhoneNumber;

            return original;
        }

        public static LibraryCardEntity Update(this LibraryCardEntity original, ILibraryCardEditable update)
        {
            var custommer = update?.Customer.Map<CustomerEntity, Customer>();

            original.Customer = custommer;
            // original.RentedBooks = update.RentedBooks;

            return original;
        }
    }
}
