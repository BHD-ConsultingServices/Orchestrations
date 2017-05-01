
namespace Spike.Adapters
{
    using System.Linq;
    using Contracts;
    using System.Collections.Generic;

    public class PageBase
    {
        public IEnumerable<T> GetPageData<T>(IQueryable<T> data, PageArgs pageArgs)
        {
            return pageArgs == null
                ? data
                : data.Skip((pageArgs.PageNumber - 1) * pageArgs.PageSize).Take(pageArgs.PageSize);
        }

        public PagedResult<T> CreatePagedResult<T>(IEnumerable<T> pageData, PageArgs pageArgs)
        {
            return new PagedResult<T>
            {
                PageSize = pageArgs?.PageSize,
                PageNumber = pageArgs?.PageNumber ?? 1,
                PageData = pageData
            };
        }
    }
}
