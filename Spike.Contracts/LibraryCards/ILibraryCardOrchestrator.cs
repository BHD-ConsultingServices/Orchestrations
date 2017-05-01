
namespace Spike.Contracts.LibraryCards
{
    using System;

    public interface ILibraryCardOrchestrator
    {
        LibraryCard AddLibraryCard(LibraryCardBase request);

        LibraryCard GetLibraryCardById(Guid id);

        LibraryCard EditLibraryCard(Guid id, ILibraryCardEditable libraryCard);

        PagedResult<LibraryCard> Search(SearchFilters filter, PageArgs pageArgs);
    }
}
