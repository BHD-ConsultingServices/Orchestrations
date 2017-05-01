
using System.Configuration;

namespace Spike.Tests
{
    using KellermanSoftware.CompareNetObjects;

    public class Utilities
    {
        public static ComparisonResult CompareObjects<T>(T expected, T actual)
        {
            var compareLogic = new CompareLogic();
            return compareLogic.Compare(expected, actual);
        }

        public static bool UsingLocalDatabase()
        {
            var connection = ConfigurationManager.ConnectionStrings["Spike.DataSource.DataContext"].ConnectionString;
            var isLocalDatabase = connection.ToLower().Contains("data source=.") || connection.ToLower().Contains("data source=localhost");

            return isLocalDatabase;
        }

    }
}
