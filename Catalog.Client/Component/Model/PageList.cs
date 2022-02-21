namespace Catalog.Client.Component.Model
{
    public class PageList<T>:List<T>
    {
        public PageList(IEnumerable<T> items, int totalcount)
        {
            AddRange(items);
            TotalCount = totalcount;
        }

        public int TotalCount { get; }
    }
}

