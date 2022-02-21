using Catalog.API.Infrastructure.Data.Services.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Catalog.API.Infrastructure.Data.Services
{
    public static class DbServiceExtentions
    {
        public  static async Task<PagedList<T>> Paging<T>(this IQueryable<T> query, PagingParam? paging =default(PagingParam))
        {
            if(paging == null)
            {
                paging = new PagingParam();
            }
            var totalcount = await query.CountAsync();
            var result = await query
                       .Skip((paging.PageIndex - 1) * paging.PageSize)
                       .Take(paging.PageSize).ToListAsync();
            return new PagedList<T>(result, totalcount);
        }


        public static IQueryable<T> Sorting<T>(this IQueryable<T> query, string? sorting =default(string))
        {
            if (string.IsNullOrEmpty(sorting))
            {
                return query;
            }
          return  query.OrderBy(sorting);
        }

    }
}
