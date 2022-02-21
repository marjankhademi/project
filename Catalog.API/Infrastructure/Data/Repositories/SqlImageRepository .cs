using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data.Repositories.Contracts;
using Catalog.API.Infrastructure.Data.Repositories.Core;

namespace Catalog.API.Infrastructure.Data.Repositories
{
    public class SqlImageRepository : SqlRepository<Image, int>, ImageRepository
    {
        public SqlImageRepository(CatalogContext context) : base(context)
        {
        }
    }
}
