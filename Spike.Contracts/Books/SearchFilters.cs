
namespace Spike.Contracts.Books
{
    using System;

    public class SearchFilters
    {
        public bool ReturnAll { get; set; } = true;

        public string AuthorName { get; set; }

        public Guid? RentedByCustomerId { get; set; }
    }
}
