
using Spike.Adapters.Books;
using Spike.Adapters.Customers;
using Spike.Contracts.Customers;

namespace Spike.Adapters.Mappings
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Contracts.Books;
    using Contracts.LibraryCards;
    using DataSource.Entities;

    public static class AutoMappers
    {
        private static bool IsInitialized { get; set; }

        private static void CheckInitialization()
        {
            if (IsInitialized) return;

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Book, BookEntity>();
                cfg.CreateMap<BookEntity, Book>();

                cfg.CreateMap<Customer, CustomerEntity>();
                cfg.CreateMap<CustomerEntity, Customer>();

                cfg.CreateMap<LibraryCard, LibraryCardEntity>();
                cfg.CreateMap<LibraryCardEntity, LibraryCard>();

                // cfg.AddProfile<FooProfile>();
            });

            IsInitialized = true;

        }

        public static IEnumerable<T> MapAll<T, TY>(this IEnumerable<TY> originals)
        {
           CheckInitialization();

            return originals?.Select(original => Mapper.Map<T>(original)).ToList();
        }
        
        public static T Map<T, TY>(this TY original)
        {
            CheckInitialization();

            return Mapper.Map<T>(original);
        }
    }
}
