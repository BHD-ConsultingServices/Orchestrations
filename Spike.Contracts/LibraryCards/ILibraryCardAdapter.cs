
namespace Spike.Contracts.LibraryCards
{
    using System;

    public interface ILibraryCardAdapter
    {
        LibraryCard AddLibraryCard(LibraryCard libraryCard);

        LibraryCard GetLibraryCard(Guid id);

        LibraryCard UpdateLibraryCard(Guid id, ILibraryCardEditable libraryCard);

        PagedResult<LibraryCard> Search(SearchFilters filters, PageArgs pageArgs);
    }
}
