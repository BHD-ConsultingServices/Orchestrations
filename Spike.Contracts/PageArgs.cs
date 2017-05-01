
namespace Spike.Contracts
{
    public class PageArgs
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string SortColumn { get; set; }

        public SortOrder SortOrder { get; set; }
    }
}
