using Catalog.Client.Component.Model;
using Catalog.Client.Services.Core;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Catalog.Client.Component.Products
{
    public partial class List
    {
        [Inject]
        public IProductService service { get; set; }
        private MudTable<Product>? _table;
        private string _searchtext;
        public async Task<TableData<Product>> GetProductData(TableState state)
        {
            var sortDirection = state.SortDirection == SortDirection.Ascending ? "asc" : "desc";
            var sortField = state.SortLabel == "" ? "Id" : state.SortLabel;
            var sort = $"{sortDirection}{sortField}";
            var request = new SearchRequestDto
            {
                PageIndex = 1,
                PageSize = 10,
                sort = sort,
                SearchText = ""
            };
            var DataTable = new TableData<Product>();
            //DataTable.TotalItems = 50;
            //DataTable.Items = new List<Product>
            //{
            //    new Product{Id=1, Name="p1", Price=1000,Description="desc1"},
            //     new Product{Id=2, Name="p2", Price=1000,Description="desc1"},
            //      new Product{Id=3, Name="p3", Price=1000,Description="desc1"},
            //};
            var result = await service.GetProducts(request);
            DataTable.TotalItems = result.TotalCount;
            DataTable.Items = result;
            return await Task.FromResult(DataTable);
        }
        public void OnSearch(string text)
        {
            _searchtext = text;
        }
    }
}