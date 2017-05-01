
namespace Spike.Adapters.Customers
{
    using System.Linq;
    using Contracts;
    using Contracts.Customers;
    using DataSource.Entities;
    using System;
    using Mappings;
    
    public class CustomerQuery : PageBase
    {
        private IQueryable<CustomerEntity> DataSet { get; set; }

        public CustomerQuery(IQueryable<CustomerEntity> dataSet)
        {
            DataSet = dataSet;
        }

        public CustomerQuery ApplyIdentityNumber(string identityNumber)
        {
            if (string.IsNullOrWhiteSpace(identityNumber)) return this;

            DataSet = DataSet.Where(c => c.IdentityNumer.Contains(identityNumber));

            return this;
        }

        private CustomerQuery ApplyBookFilters(Guid? bookId, string titelName)
        {
            if (bookId == null && string.IsNullOrWhiteSpace(titelName)) return this;

            DataSet = DataSet.Where(l => l.RentedBooks.Any(b =>
                    (bookId != null && b.Id == bookId.Value) ||
                    (!string.IsNullOrWhiteSpace(titelName) && b.Title.ToLower().Contains(titelName.ToLower()))
               ));

            return this;
        }

        public CustomerQuery ApplyCustomerName(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName)) return this;

            DataSet = DataSet.Where(c => c.Name.Contains(customerName));

            return this;
        }

        public PagedResult<Customer> Search(SearchFilters filter, PageArgs pageArgs)
        {
            ApplyIdentityNumber(filter.CustomerIdentityNumber)
                .ApplyIdentityNumber(filter.CustomerName)
                .ApplyBookFilters(filter.RentedBookId, filter.OutstandingBookTitle);

            var pagedResult = GetPageData(DataSet, pageArgs).ToList();
            var mappedData = pagedResult.Select(c => c.Map());

            return CreatePagedResult(mappedData, pageArgs);
        }
    }
}
