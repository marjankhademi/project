using Catalog.Client.Component.Model;
using Catalog.Client.Services.Core;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Catalog.Client.Component.Products
{
    public partial class List
    {
        [Inject]
        public IProductService Service { get; set; }
        private MudTable<Product> _table;
        private string _searchtext="";

        [Parameter]

        public EventCallback<SelectedProductEventArgs> OnSelectedProductChanged { get; set; }
        public async Task<TableData<Product>> GetProductData(TableState state)
        {
            var sortDirection = state.SortDirection == SortDirection.Ascending ? "asc" : "desc";
            Console.WriteLine(state.SortLabel);
            var sortField = state.SortLabel == null ? "Id" : state.SortLabel;
            
            
             var Sort = $"{sortField} {sortDirection}";
            Console.WriteLine(_searchtext);
            var request = new SearchRequestDto
            {

                PageIndex = state.Page+1,
                PageSize = state.PageSize,
                SearchText = _searchtext,
                sort = Sort
            };
            var DataTable = new TableData<Product>();
            //DataTable.TotalItems = 50;
            //DataTable.Items = new List<Product>
            //{
            //    new Product{Id=1, Name="p1", Price=1000,Description="desc1"},
            //     new Product{Id=2, Name="p2", Price=1000,Description="desc1"},
            //      new Product{Id=3, Name="p3", Price=1000,Description="desc1"},
            //};


            var result = await Service.GetProducts(request);
            DataTable.TotalItems = result.TotalCount;
            DataTable.Items = result;
            Console.WriteLine(DataTable);

            return await Task.FromResult(DataTable);
        }
        public void OnSearch(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            _searchtext = text;

            Console.WriteLine("1111");
            
            Console.WriteLine(_searchtext);

           _table.ReloadServerData();
        }
        public void OnSelectedItemChanged(HashSet<Product> selecteds)
        {
           int[] ids=selecteds.Select(p => p.Id).ToArray();
            var eargs= new SelectedProductEventArgs(ids);
            OnSelectedProductChanged.InvokeAsync(eargs);
        }
    }
}