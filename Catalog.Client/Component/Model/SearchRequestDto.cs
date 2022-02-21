namespace Catalog.Client.Component.Model
{
    public class SearchRequestDto
    {

        public SearchRequestDto()
        {
            PageSize = 10;
            PageIndex = 1;
            SearchText = string.Empty;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string? SearchText { get; set; }
        public string? sort { get; set; }
    }


}
