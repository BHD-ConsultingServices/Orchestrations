
namespace Spike.StubData.Mocking
{
    using Rhino.Mocks;
    using Contracts.Customers;
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Builders;

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

        public CustomerAdapterMocks MockGetCustomer()
        {
            Adapter
                .Stub(x => x.GetCustomer(Arg<Guid>.Is.Anything))
                .Return(new CustomerBuilder().JohnDoe().Build());

            return this;
        }

        public CustomerAdapterMocks MockUpdateCustomer()
        {
            Adapter
                .Stub(x => x.UpdateCustomer(Arg<Guid>.Is.Anything, Arg<ICustomerEditable>.Is.Anything))
                .WhenCalled(x =>
                {
                    var id = (Guid)x.Arguments[0];
                    var update = (ICustomerEditable)x.Arguments[1];

                    var updatedCustomer = new CustomerBuilder(id).Generate(1).Build();
                    updatedCustomer.PhoneNumber = update.PhoneNumber;
                    updatedCustomer.Adress = update.Adress;

                    x.ReturnValue = updatedCustomer;
                });

            return this;
        }

        public CustomerAdapterMocks MockSearch()
        {
            Adapter
                .Stub(x => x.Search(Arg<SearchFilters>.Is.Anything, Arg<PageArgs>.Is.Anything))
                .Return(new PagedResult<Customer>
                {
                    PageNumber = 1,
                    PageSize = null,
                    PageData = new List<Customer>
                    {
                        new CustomerBuilder().JohnDoe().Build(),
                        new CustomerBuilder().JaneDoe().Build()
                    }
                });

            return this;
        }

        public ICustomerAdapter Build()
        {
            return Adapter;
        }
    }
}
