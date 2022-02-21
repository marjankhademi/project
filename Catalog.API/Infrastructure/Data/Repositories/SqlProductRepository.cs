using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data.Repositories.Contracts;
using Catalog.API.Infrastructure.Data.Repositories.Core;
using Catalog.API.Infrastructure.Data.Services;
using Catalog.API.Infrastructure.Data.Services.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Catalog.API.Infrastructure.Data.Repositories
{
    public class SqlProductRepository : SqlRepository<Product, int>, IProductRepository
    {
        public SqlProductRepository(CatalogContext context) : base(context)
        {
        }

        //  public override async Task<IEnumerable<Product>> search(string searchText, PagingParam paging)
        //  {
        //   return  await _set
        // .Where(product => EF.Functions.Like(product.Id.ToString(), $"%{searchText}%") ||
        //           EF.Functions.Like(product.Name, $"%{searchText}%") ||
        //           EF.Functions.Like(product.Price.ToString(), $"%{searchText}%")||
        //            EF.Functions.Like(product.Description, $"%{searchText}%")  
        //      )
        //       .Skip((paging.PageIndex-1)*paging.PageSize)
        //        .Take(paging.PageSize)
        //        .ToListAsync();
        //}

        public Task<IEnumerable<Product>> GetBymaxPrice(int maxprice) => Filter(p => p.Price <= maxprice);


        public Task<IEnumerable<Product>> GetByPrice(int minprice) => Filter(p => p.Price >= minprice);

        public Task<IEnumerable<Product>> GetByRangePrice(int minprice, int maxprice) => Filter(p => p.Price <= maxprice && p.Price >= minprice);


        public Task<IEnumerable<Product>> GetByQuery(int minprice, int maxprice) => Filter($"p => p.Price <= {maxprice} && p.Price >= {minprice}");

        public override async Task<PagedList<Product>> search(string searchText, PagingParam paging, string sorting = "")
        {
            return await _set
               .Where(product => EF.Functions.Like(product.Id.ToString(), $"%{searchText}%") ||
                                 EF.Functions.Like(product.Name, $"%{searchText}%") ||
                                 EF.Functions.Like(product.Price.ToString(), $"%{searchText}%") ||
                                 EF.Functions.Like(product.Description, $"%{searchText}%")
                      )
                      // .Skip((paging.PageIndex - 1) * paging.PageSize)
                      // .Take(paging.PageSize)
                      //.ToListAsync();
                     // .OrderBy(sorting)
                     .Sorting(sorting)
                      .Paging(paging);

            //public Task search()
            // {
            //    throw new NotImplementedException();
            // }
        }

        public Task search()
        {
            throw new NotImplementedException();
        }
    }
}
