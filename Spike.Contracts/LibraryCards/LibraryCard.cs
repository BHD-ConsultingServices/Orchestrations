

namespace Spike.Contracts.LibraryCards
{
    using System;
    using System.Linq;

    public class LibraryCard : LibraryCardBase
    {
        public Guid Id { get; set; }

        public override string ToString()
        {
            return $"ID [{Id}] Customer [{Customer}] No. Rented Books [{RentedBooks?.Count() ?? 0}]";
        }
    }
}
