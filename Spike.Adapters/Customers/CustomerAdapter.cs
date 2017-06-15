
namespace Spike.Adapters.Customers
{
    using System;
    using Contracts;
    using Contracts.Customers;
    using System.Linq;
    using Mappings;

    public class CustomerAdapter : AdapterBase, ICustomerAdapter
    {
        public Customer AddCustomer(Customer customer)
        {
            var result = Context.Customers.Add(customer.Map());
            return result.Map();
        }

        public Customer GetCustomer(Guid id)
        {
            var customer = Context.Customers.Single(c => c.Id == id);
            return customer.Map();
        }

        public Customer UpdateCustomer(Guid id, ICustomerEditable customer)
        {
            var current = Context.Customers.Single(c => c.Id == id);

            current = current.Update(customer);

            return current.Map();
        }

        public PagedResult<Customer> Search(SearchFilters filters, PageArgs pageArgs)
        {
            var query = new CustomerQuery(Context.Customers);
            return query.Search(filters, pageArgs);
        }
    }
}
