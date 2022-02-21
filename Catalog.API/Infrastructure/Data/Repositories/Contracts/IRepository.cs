using Catalog.API.Domain.Data.Core;
using Catalog.API.Infrastructure.Data.Services.Paging;
using System.Linq.Expressions;

namespace Catalog.API.Infrastructure.Data.Repositories.Contracts
{
    public interface IRepository<T, Key>
        where T : IEntity<Key>
      //  where Key : IEquatable<Key>
    {
       Task<T> GetById(Key id);
        Task AddNew(T entity);
        Task<IEnumerable<T>> GetAll();
        Task Update(T entity);
        Task Remove(T entity);


        //filtering,paging,sorting
        Task<IEnumerable<T>> Filter( Expression<Func<T, bool>> predicate );

        Task<IEnumerable<T>> Filter(string predicate);
        Task<PagedList<T>> search(string searchText,PagingParam paging =null, string sorting = "");
    }
}
