
namespace Spike.Orchestrations.LibraryCardOrchestrations
{
    using System;
    using Contracts;
    using Contracts.LibraryCards;
    using Contracts.Customers;
    using LibCards = Contracts.LibraryCards;
    using Common;

    public class LibraryCardOrchestrator : ILibraryCardOrchestrator
    {
        private ICustomerAdapter CustomerAdapter { get; }
        private ILibraryCardAdapter LibraryCardAdapter { get; }
        
        // DI Will Inject Requires Empty Constructor
        public LibraryCardOrchestrator()
        {
            LibraryCardAdapter = DependencyFactory.Resolve<ILibraryCardAdapter>();
        }

        public LibraryCardOrchestrator(ICustomerAdapter customerAdapter,
            ILibraryCardAdapter libraryCardAdapter)
        {
            CustomerAdapter = customerAdapter;
            LibraryCardAdapter = libraryCardAdapter;
        }

        public LibraryCard AddLibraryCard(LibraryCardBase libraryCard)
        {
            return Worker.AddLibraryCard(LibraryCardAdapter, libraryCard);
        }

        public LibraryCard GetLibraryCardById(Guid id)
        {
            return LibraryCardAdapter.GetLibraryCard(id);
        }

        public PagedResult<LibraryCard> Search(LibCards.SearchFilters filter, PageArgs pageArgs)
        {
            return LibraryCardAdapter.Search(filter, pageArgs);
        }

        public LibraryCard EditLibraryCard(Guid id, ILibraryCardEditable libraryCard)
        {
            return LibraryCardAdapter.UpdateLibraryCard(id, libraryCard);
        }
    }
}
