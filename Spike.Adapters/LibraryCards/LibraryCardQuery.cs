
using Spike.Adapters.Mappings;

namespace Spike.Adapters.LibraryCards
{
    using System;
    using System.Linq;
    using Contracts;
    using Contracts.LibraryCards;
    using DataSource.Entities;

    public class LibraryCardQuery : PageBase
    {
        private IQueryable<LibraryCardEntity> DataSet { get; set; }

        public LibraryCardQuery(IQueryable<LibraryCardEntity> dataSet)
        {
            DataSet = dataSet;
        }

        private LibraryCardQuery ApplyCustomerNameFilter(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName)) return this;

            DataSet = DataSet.Where(l => l.Customer.Name.ToLower().Contains(customerName.ToLower()));

            return this;
        }

        public PagedResult<LibraryCard> Search(SearchFilters filter, PageArgs pageArgs)
        {
            ApplyCustomerNameFilter(filter.CustomerName);

            var pagedResult = GetPageData(DataSet, pageArgs).ToList();
            var mappedData = pagedResult.Select(c => c.Map());

            return CreatePagedResult(mappedData, pageArgs);
        }
    }
}
