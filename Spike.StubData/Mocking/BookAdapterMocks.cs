
namespace Spike.StubData.Mocking
{
    using System;
    using Rhino.Mocks;
    using Contracts.Books;
    using System.Collections.Generic;
    using Contracts;
    using Builders;

    public class BookAdapterMocks
    {
        private IBookAdapter Adapter { get; } = MockRepository.GenerateMock<IBookAdapter>();

        public BookAdapterMocks MockAddBook()
        {
            Adapter
                .Stub(x => x.AddBook(Arg<Book>.Is.Anything))
                // Add custom logic that can reference input parms
                .WhenCalled(x =>
                {
                    x.ReturnValue = (Book)x.Arguments[0];
                });

            return this;
        }

        public BookAdapterMocks MockGetBook()
        {
            Adapter
                .Stub(x => x.GetBook(Arg<Guid>.Is.Anything))
                .Return(new BookBuilder().FiveDysfunctions().Build());

            return this;
        }

        public BookAdapterMocks MockUpdateBook()
        {
            Adapter
                .Stub(x => x.UpdateBook(Arg<Guid>.Is.Anything, Arg<IBookEditable>.Is.Anything))
                .WhenCalled(x =>
                    {
                        var id = (Guid) x.Arguments[0];
                        var update = (IBookEditable) x.Arguments[1];

                        var updatedBook = new BookBuilder(id).Generator(1).Build();
                        updatedBook.Author = update.Author;
                        updatedBook.ReleaseDate = update.ReleaseDate;

                        x.ReturnValue = updatedBook;
                 });

            return this;
        }

        public BookAdapterMocks MockSearch()
        {
            Adapter
                .Stub(x => x.Search(Arg<SearchFilters>.Is.Anything, Arg<PageArgs>.Is.Anything))
                .Return(new PagedResult<Book>
                {
                    PageNumber = 1,
                    PageSize = null,
                    PageData = new List<Book>
                    {
                        new BookBuilder().FiveDysfunctions().Build(),
                        new BookBuilder().ThePhoenixProject().Build()
                    }
                });

            return this;
        }
        
        public IBookAdapter Build()
        {
            return Adapter;
        }
    }
}
