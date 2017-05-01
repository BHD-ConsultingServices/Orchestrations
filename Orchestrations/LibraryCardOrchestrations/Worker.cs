
namespace Spike.Orchestrations.LibraryCardOrchestrations
{
    using System;
    using Contracts.LibraryCards;
 
    public static class Worker
    {
        public static LibraryCard AddLibraryCard(ILibraryCardAdapter adapter, LibraryCardBase libraryCard)
        {
            var newLibraryCard = (LibraryCard)libraryCard;
            newLibraryCard.Id = Guid.NewGuid();

            return adapter.AddLibraryCard(newLibraryCard);
        }
    }
}
