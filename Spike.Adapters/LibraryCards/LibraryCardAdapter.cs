

namespace Spike.Adapters.LibraryCards
{
    using System;
    using Contracts;
    using Contracts.LibraryCards;
    using Mappings;
    using DataSource.Entities;
    using System.Linq;
    using Contracts.Customers;

    public class LibraryCardAdapter : AdapterBase, ILibraryCardAdapter
    {
        public LibraryCard AddLibraryCard(LibraryCard libraryCard)
        {
            // Response from context does not iclude foreign key objects so wont match tests
            Context.LibraryCards.Add(libraryCard.Map());
            
            return libraryCard;
        }

        public LibraryCard GetLibraryCard(Guid id)
        {
            var result = Context.LibraryCards.Single(l => l.Id == id);
            return result.Map<LibraryCard, LibraryCardEntity>();
        }

        public LibraryCard UpdateLibraryCard(Guid id, ILibraryCardEditable libraryCard)
        {
            var card = Context.LibraryCards.Single(l => l.Id == id);
            card.Customer = libraryCard.Customer.Map<CustomerEntity, Customer>();
            return card.Map<LibraryCard, LibraryCardEntity>();
        }

        public PagedResult<LibraryCard> Search(Contracts.LibraryCards.SearchFilters filters, PageArgs pageArgs)
        {
            var query = new LibraryCardQuery(Context.LibraryCards);
            return query.Search(filters, pageArgs);
        }
    }
}
