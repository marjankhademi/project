using Catalog.API.Domain;

namespace Catalog.API.Infrastructure.Data.Repositories.Contracts
{
    public interface IProductRepository : IRepository<Product, int>
    {
      public Task<IEnumerable<Product>> GetByPrice( int minprice);
        public Task<IEnumerable<Product>> GetBymaxPrice(int maxprice);
        public Task<IEnumerable<Product>> GetByRangePrice(int minprice ,int maxprice);
        public Task<IEnumerable<Product>> GetByQuery(int minprice, int maxprice);
        Task search();
    }
}
