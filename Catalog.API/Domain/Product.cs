using Catalog.API.Domain.Data.Core;

namespace Catalog.API.Domain
{
    //Principal Entity
    //Principal Key (Primary, Alternate)
    //Navigation Property
    public class Product : Entity<int>
    {
        //public string PartNumber { get; set; }
        //public string InventoryCode { get; set; }
        //public string IranCode { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public override string ToString() => $"Id : {Id}, Name : {Name}";

      public Product()
        {
            Images = new List<Image>();
       }

        //Eager, Explicit, Lazy
        public List<Image> Images { get; set; }
    }
}