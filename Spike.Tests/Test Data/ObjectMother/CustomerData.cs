
namespace Spike.Tests.Test_Data.ObjectMother
{
    using Adapters.Customers;
    using Contracts.Customers;
    using StubData.Builders;

    public class CustomerData
    {
        public void Initialize()
        {
            var adapter = new CustomerAdapter();

            JohnDoe = adapter.AddCustomer(new CustomerBuilder().JohnDoe(
                ObjectMother.Instance.Books.FiveDysfunctions).Build());
            JaneDoe = adapter.AddCustomer(new CustomerBuilder().JaneDoe(
                ObjectMother.Instance.Books.PhoenixProject).Build());

            adapter.SaveChanges();
        }

        public Customer JohnDoe { get; set; }

        public Customer JaneDoe { get; set; }

    }
}
