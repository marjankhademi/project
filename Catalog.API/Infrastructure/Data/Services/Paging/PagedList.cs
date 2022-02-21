namespace Catalog.API.Infrastructure.Data.Services.Paging
{
    public class PagedList<T>:List<T>
    {
        public PagedList( IEnumerable<T> items,int totalcount )
        {
            AddRange(items);
            TotalCount = totalcount;
        }

        public int TotalCount { get; }
    }
}
