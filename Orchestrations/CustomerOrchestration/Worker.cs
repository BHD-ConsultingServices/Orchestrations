
namespace Spike.Orchestrations.CustomerOrchestration
{
    using System;
    using Contracts.Customers;
    using System.Collections.Generic;

    public static class Worker
    {
        public static Customer AddCustomer(ICustomerAdapter adapter, CustomerBase customer)
        {
            var newCustomer = (Customer)customer;
            newCustomer.Id = Guid.NewGuid();

            return adapter.AddCustomer(newCustomer);
        }

        public static IEnumerable<Customer> GetCustomerForRentedBook(ICustomerAdapter customerAdapter, Guid rentedBookId)
        {
            var searchFilter = new SearchFilters
            {
                RentedBookId = rentedBookId
            };

            return customerAdapter.Search(searchFilter, null).PageData;
        }
    }
}
