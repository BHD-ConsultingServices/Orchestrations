
namespace Spike.Contracts.Customers
{
    using System;

    public class SearchFilters
    {
        public string CustomerIdentityNumber { get; set; }

        public string CustomerName { get; set; }

        public string OutstandingBookTitle { get; set; }

        public Guid? RentedBookId { get; set; }
    }
}
