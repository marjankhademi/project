using Catalog.Client.Component.Model;
using Catalog.Client.Services.Core;

namespace Catalog.Client.Services
{
    public class ProductService : IProductService
    {
        public async Task<PageList<Product>> GetProducts(SearchRequestDto request)
        {
            await Task.Delay(700);
            var products = new List<Product>
            {
                new Product{Id=1, Name="p1", Price=1000,Description="desc1"},
                 new Product{Id=2, Name="p2", Price=1000,Description="desc1"},
                  new Product{Id=3, Name="p3", Price=1000,Description="desc1"},
            };
            var result = new PageList<Product>(products, 50);
            return  await Task.FromResult(result);
        }
    }
}
