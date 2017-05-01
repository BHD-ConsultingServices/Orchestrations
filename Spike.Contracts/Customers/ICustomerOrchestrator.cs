
namespace Spike.Contracts.Customers
{
    using System;
    using System.Collections.Generic;

    public interface ICustomerOrchestrator
    {
        Customer AddCustomer(CustomerBase request);

        Customer GetCustomerById(Guid id);

        Customer EditCustomer(Guid id, ICustomerEditable customer);

        PagedResult<Customer> Search(SearchFilters filter, PageArgs pageArgs);

        IEnumerable<Customer> GetCustomerByRentedBook(Guid bookId);
    }
}
