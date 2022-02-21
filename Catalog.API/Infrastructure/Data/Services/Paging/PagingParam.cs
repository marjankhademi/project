namespace Catalog.API.Infrastructure.Data.Services.Paging
{
    public class PagingParam
    {
        private int MaxPageSize = 50;
        private int DefultPageSize = 10;
        private int _PageSize;

        public PagingParam()
        {
            PageIndex = 1;
            PageSize= DefultPageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize {
            get => _PageSize; 
            set =>_PageSize=value>MaxPageSize?MaxPageSize:value;
        }
    }
}
