
using Spike.Contracts.Customers;

namespace Spike.Tests.Waldos
{
    using Adapters.Customers;
    using StubData.Builders;

    public class CustomerWaldo
    {
        public static Customer PrepareJohnDoeCustomer()
        {
            var adapter = new CustomerAdapter();
            var customer = adapter.AddCustomer(new CustomerBuilder().JohnDoe().Build());

            adapter.SaveChanges();

            return customer;
        }
    }
}
