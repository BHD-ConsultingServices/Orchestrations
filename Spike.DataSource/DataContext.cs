
namespace Spike.DataSource
{
    using System.Data.Entity;
    using Entities;

    public class DataContext : DbContext,  IDataContext
    {
        public DataContext(): base("name=Spike.DataSource.DataContext") 
        {
           //  Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>().ToTable("Books");
            modelBuilder.Entity<CustomerEntity>().ToTable("Customers");
            modelBuilder.Entity<LibraryCardEntity>().ToTable("LibraryCards");

            modelBuilder.Entity<CustomerEntity>()
             .HasMany(l => l.RentedBooks)
             .WithMany(l => l.RentedCustomer)
             .Map(cs =>
             {
                 cs.MapLeftKey("BookId");
                 cs.MapRightKey("CustomerId");
                 cs.ToTable("RentedBooks");
             });

        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<LibraryCardEntity> LibraryCards { get; set; }
    }
}
