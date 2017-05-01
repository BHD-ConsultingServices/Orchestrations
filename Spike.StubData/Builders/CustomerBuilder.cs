
using System.Collections.Generic;
using Spike.Contracts.Books;

namespace Spike.StubData.Builders
{
    using System;
    using Contracts.Customers;

    public class CustomerBuilder : Customer
    {
        public CustomerBuilder(Guid? id = null)
        {
            id = id ?? Guid.NewGuid();
        }

        public CustomerBuilder Generate(int seed)
        {
            this.Id = Guid.NewGuid();
            this.Adress = $"Address [{seed}]";
            this.IdentityNumer = $"81049283746{seed}";
            this.Name = $"Name [{seed}]";
            this.PhoneNumber = $"07223445{seed}";

            return this;
        }

        public CustomerBuilder JohnDoe(Book rentedBook = null)
        {
            this.Id = Guid.Parse("2FBB092F-9CFB-4BED-81CC-B2EB9DF70E1A");
            this.Name = "John Doe";
            this.Adress = "Tree Street 23, Brooklyn, 0234";
            this.IdentityNumer = "8304057323222";
            this.PhoneNumber = "0723847564";

            var rentedBooks = new List<Book>
            {
                rentedBook ?? new BookBuilder().FiveDysfunctions()
            };

            this.RentedBooks = rentedBooks;

            return this;
        }

        public CustomerBuilder JaneDoe(Book rentedBook = null)
        {
            this.Id = Guid.Parse("AAF94A34-2F2D-4C46-B9D5-3A9439C4F7FE");
            this.Name = "Jane Doe";
            this.Adress = "Red flower 2, NY, 2134";
            this.IdentityNumer = "8103928374633";
            this.PhoneNumber = "0843847566";

            var rentedBooks = new List<Book>
            {
                rentedBook ?? new BookBuilder().ThePhoenixProject()
            };

            this.RentedBooks = rentedBooks;

            return this;
        }

        public Customer Build()
        {
            return new Customer
            {
                Id = this.Id,
                Name = this.Name,
                Adress = this.Adress,
                PhoneNumber = this.PhoneNumber,
                IdentityNumer = this.IdentityNumer
            };
        }
    }
}
