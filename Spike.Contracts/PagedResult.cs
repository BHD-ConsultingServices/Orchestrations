
namespace Spike.Contracts
{
    using System.Collections.Generic;

    public class PagedResult<T>
    {
       public int PageNumber { get; set; }

       public int? PageSize { get; set; }

       public IEnumerable<T> PageData { get; set; }
    }
}
