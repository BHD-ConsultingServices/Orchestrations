using System;
using System.Linq;

namespace Spike.Contracts.Customers
{
    public class Customer : CustomerBase
    {
        public Guid Id { get; set; }

        public override string ToString()
        {
            return $"ID [{Id} Name [{Name}] IdentityNumber [{IdentityNumer}] Address [{Adress}] PhoneNumber [{PhoneNumber}] No. Books [{RentedBooks?.Count() ?? 0}]";
        }
    }
}
