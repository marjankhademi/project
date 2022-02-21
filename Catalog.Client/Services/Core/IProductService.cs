using Catalog.Client.Component.Model;

namespace Catalog.Client.Services.Core
{
    public interface IProductService
    {
        Task<PageList<Product>> GetProducts(SearchRequestDto request);
    }
}
