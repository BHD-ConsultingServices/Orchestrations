
namespace Spike.StubData.Builders
{
    using System;
    using Contracts.LibraryCards;
    using System.Collections.Generic;
    using Contracts.Books;
    using Contracts.Customers;

    public class LibraryCardBuilder : LibraryCard
    {
        public LibraryCardBuilder(Guid? id = null)
        {
            id = id ?? Guid.NewGuid();
        }

        public LibraryCardBuilder Generate(int seed)
        {
            this.Customer = new CustomerBuilder().Generate(seed).Build();
            this.RentedBooks = new List<Book>
            {
                new BookBuilder().Generator(seed).Build()
            };

            return this;
        }

        public LibraryCardBuilder JohnDoeCard(Customer customer = null)
        {
            this.Id = Guid.Parse("DEEBFB51-7F4F-4779-AA5F-AA980DC73A64");
            this.Customer = customer ?? new CustomerBuilder().JohnDoe().Build();

            return this;
        }

        public LibraryCardBuilder JaneDoeCard(Customer customer = null)
        {
            this.Id = Guid.Parse("B7CE8BAC-6176-4672-8E46-C0501A50E0B4");
            this.Customer = customer ?? new CustomerBuilder().JaneDoe().Build();

            return this;
        }

        public LibraryCard Build()
        {
            return new LibraryCard
            {
                Id = this.Id,
                Customer = this.Customer,
                RentedBooks = this.RentedBooks
            };
        }
    }
}
