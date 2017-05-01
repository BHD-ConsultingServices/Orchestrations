
namespace Spike.Adapters
{
    using DataSource;

    public abstract class AdapterBase
    {
        protected DataContext Context { get; } = new DataContext();

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
