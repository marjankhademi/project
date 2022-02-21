using Catalog.API.Domain.Data.Core;

namespace Catalog.API.Domain
{
    //Dependent Entity
    //Foreign Key
    public class Image : Entity<int>
    {
        //Blob File
        public string Name { get; set; }
        public int ProductId { get; set; }
       // public string ProductPartNumber { get; set; }

       // public Product Owner { get; set; }
    }
}
