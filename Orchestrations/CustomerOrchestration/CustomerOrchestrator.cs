
namespace Spike.Orchestrations.CustomerOrchestration
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Contracts.Customers;
    using Common;

    public class CustomerOrchestrator : ICustomerOrchestrator
    {
        private ICustomerAdapter CustomerAdapter { get; }

        // DI Will Inject Requires Empty Constructor
        public CustomerOrchestrator()
        {
            CustomerAdapter = DependencyFactory.Resolve<ICustomerAdapter>();
        }

        public CustomerOrchestrator(ICustomerAdapter customerAdapter)
        {
            CustomerAdapter = customerAdapter;
        }

        public Customer AddCustomer(CustomerBase customer)
        {
            return Worker.AddCustomer(CustomerAdapter, customer);
        }

        public Customer GetCustomerById(Guid id)
        {
            return CustomerAdapter.GetCustomer(id);
        }

        public PagedResult<Customer> Search(SearchFilters filter, PageArgs pageArgs)
        {
            return CustomerAdapter.Search(filter, pageArgs);
        }

        public Customer EditCustomer(Guid id, ICustomerEditable customer)
        {
            return CustomerAdapter.UpdateCustomer(id, customer);
        }

        public IEnumerable<Customer> GetCustomerByRentedBook(Guid bookId)
        {
            return Worker.GetCustomerForRentedBook(CustomerAdapter, bookId);
        }
    }
}
