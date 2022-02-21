using Catalog.API.Domain;
using System.Net.Mime;

namespace Catalog.API.Infrastructure.Data.Repositories.Contracts
{
    public interface ImageRepository : IRepository<Image, int>
    {
       // Task AddNew(MediaTypeNames.Image image);
    }
}
