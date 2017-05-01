
using System;
using Spike.Adapters.Mappings;

namespace Spike.Adapters.Books
{
    using System.Linq;
    using Contracts;
    using Contracts.Books;
    using DataSource.Entities;

    public class BookQuery : PageBase
    {
        private IQueryable<BookEntity> DataSet { get; set;  }
        
        public BookQuery(IQueryable<BookEntity> dataSet)
        {
            DataSet = dataSet;
        }

        public BookQuery ApplyNameFilter(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName)) return this;

            DataSet = DataSet.Where(b => b.Author.Contains(customerName));

            return this;
        }

        private BookQuery ApplyRentedCustomerFilter(Guid? customerId)
        {
            if (customerId == null) return this;

            DataSet = DataSet.Where(b => b.RentedCustomer.Any(c => c.Id == customerId));

            return this;
        }

        public PagedResult<Book> Search(SearchFilters filter, PageArgs pageArgs)
        {
            ApplyNameFilter(filter.AuthorName)
                .ApplyRentedCustomerFilter(filter.RentedByCustomerId);

            var pagedResult = GetPageData(DataSet, pageArgs).ToList();
            var mappedData = pagedResult.Select(c => c.Map<Book, BookEntity>());

            return CreatePagedResult(mappedData, pageArgs);
        }
    }
}
