
namespace Spike.StubData.Mocking
{
    using Rhino.Mocks;
    using Contracts.Customers;

    public class CustomerAdapterMocks
    {
        private ICustomerAdapter Adapter { get; } = MockRepository.GenerateMock<ICustomerAdapter>();

        public CustomerAdapterMocks MockAddCustomer()
        {
            Adapter
                .Stub(x => x.AddCustomer(Arg<Customer>.Is.Anything))
                .WhenCalled(x =>
                {
                    x.ReturnValue = (Customer)x.Arguments[0];
                });

            return this;
        }

        public ICustomerAdapter Build()
        {
            return Adapter;
        }
    }
}
