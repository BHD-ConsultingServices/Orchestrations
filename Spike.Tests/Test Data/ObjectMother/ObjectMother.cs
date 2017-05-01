
namespace Spike.Tests.Test_Data.ObjectMother
{
    using System.Security.Authentication;
    using DataSource;

    public class ObjectMother
    {
        private static ObjectMother _instance;

        public static ObjectMother Instance {
            get
            {
                if (_instance != null) return _instance;

                _instance = new ObjectMother();
                _instance.Initialize();

                return _instance;
            }
        }

        public bool VerifyInitialization()
        {
            return _instance != null;
        } 

        public static void ClearTestData()
        {
            if (!Utilities.UsingLocalDatabase())
            {
                throw new AuthenticationException("You can only delete and recreate local databases when doing Unit Testing.");
            }

            var context = new DataContext();
            context.Database.Delete();
            context.Database.CreateIfNotExists();

            _instance = null;
        }

        private void Initialize()
        {
            Books = new BookData();
            Customers = new CustomerData();
            LibraryCards = new LibraryCardData();

            Books.Initalize();
            Customers.Initialize();
            LibraryCards.Initalize();
        }

        public BookData Books { get; set; }

        public CustomerData Customers { get; set; }

        public LibraryCardData LibraryCards { get; set; }
    }
}
