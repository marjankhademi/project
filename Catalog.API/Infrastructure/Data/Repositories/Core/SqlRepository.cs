using Catalog.API.Domain.Data.Core;
using Catalog.API.Infrastructure.Data.Repositories.Contracts;
using Catalog.API.Infrastructure.Data.Services.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Catalog.API.Infrastructure.Data.Repositories.Core
{
    public class SqlRepository<T, Key> : IRepository<T, Key>
        where T : class, IEntity<Key>
       //  where Key : IEquatable<Key>
    {
        private CatalogContext _context;
        protected DbSet<T> _set;

        public SqlRepository(CatalogContext context)//DI
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual async Task AddNew(T entity)
        {
           await _set.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate) =>await Task.Run(() => _set.Where(predicate).ToListAsync());

        public async Task<IEnumerable<T>> Filter(string predicate) =>await Task.Run(() => _set.Where(predicate).ToListAsync());


        //public search for any type
       public virtual Task<PagedList<T>> search(string searchText, 
           PagingParam? paging=default(PagingParam),
           string? sorting=default(string))
        {
            throw new NotImplementedException();
       }
        //specific search
       // public async Task<IEnumerable<T>> search(string predicate,PagingParam paging) => await Task.Run(() => _set.Where(predicate).ToListAsync());

        //     public  Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate) =>
        //    Task.Run(() => _set.Where(predicate).AsEnumerable());
        public async Task<IEnumerable<T>> GetAll() => await _set.ToListAsync();

      //  public Task<T> GetById(Key id)
      //  {
      //      throw new NotImplementedException();
      //  }



       //public async Task<T >GetById(Key id) => await  _set.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
       public async Task<T> GetById(Key id) => await _set.FindAsync(id);

        public async Task Remove(T entity)
        {
         _set.Remove(entity);
         await _context.SaveChangesAsync();
        }

      

        //  public async Task Remove(T entity)
        //  {
        //      _set.Remove(entity);
        //      return _context.SaveChangesAsync();
        //  }

        //Proxy(Design (CLR), RunTime(DLR))
        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
           return _context.SaveChangesAsync();
        }

    //  Task<PagedList<T>> IRepository<T, Key>.search(string searchText, PagingParam paging)
//
       //     throw new NotImplementedException();
    //  }
    }
}
