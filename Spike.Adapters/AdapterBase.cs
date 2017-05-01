using Spike.DataSource;

namespace Spike.Adapters
{
    public abstract class AdapterBase
    {
        protected DataContext Context { get; } = new DataContext();

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
