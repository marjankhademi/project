using Catalog.Client.Component.Model;
using Catalog.Client.Services.Core;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;

namespace Catalog.Client.Services
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _option;
        public ProductService(HttpClient http)
        {
            _http = http;
            _option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<PageList<Product>> GetProducts(SearchRequestDto request)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["PageSize"] = request.PageSize.ToString(),
                ["PageIndex"] = request.PageIndex.ToString(),
                ["SearchText"] = request.SearchText,
                ["sort"] = request.sort,
            };
            var urii = QueryHelpers.AddQueryString("Product", queryStringParam);
            Console.WriteLine(urii);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, urii);
            var httpresponse= await _http.SendAsync(httpRequest);
            var totalCount =int.Parse(httpresponse.Headers.GetValues("X-TotalCount").First());
            var content = await httpresponse.Content.ReadAsStringAsync();
            var Products=JsonSerializer.Deserialize<List<Product>>(content, _option);
            //await Task.Delay(700);
            //var products = new List<Product>
            //{
            //    new Product{Id=1, Name="p1", Price=1000,Description="desc1"},
            //     new Product{Id=2, Name="p2", Price=1000,Description="desc1"},
            //      new Product{Id=3, Name="p3", Price=1000,Description="desc1"},
            //};
            var result = new PageList<Product>(Products, totalCount);
            Console.WriteLine(result);
            return  await Task.FromResult(result);
        }
    }
}
