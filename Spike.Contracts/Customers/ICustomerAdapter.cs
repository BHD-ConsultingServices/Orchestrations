
namespace Spike.Contracts.Customers
{
    using System;

    public interface ICustomerAdapter
    {
        Customer AddCustomer(Customer customer);

        Customer GetCustomer(Guid id);

        Customer UpdateCustomer(Guid id, ICustomerEditable customer);

        PagedResult<Customer> Search(SearchFilters filters, PageArgs pageArgs);
    }
}
