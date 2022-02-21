using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Application.Models.ProductDtos
{
    public class UpdateProductDto : IValidatableObject
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Name))
                results.Add(new ValidationResult("Name is required!", new[] { "Name" }));
            else if (!Name.ToString().ToCharArray().ToList().All(c => char.IsLetter(c)))
                results.Add(new ValidationResult("Invalid Name", new[] { "Name" }));

            if (Price < 100 || Price > 500)
                results.Add(new ValidationResult("Invalid Price", new[] { "Price" }));

            if (Name == "phone" && Price == 156)
                //results.Add(new ValidationResult("Invalid Price", new[] { "Price" }));
                results.Add(new ValidationResult("Invalid Price", new[] { "Name", "Price" }));

            //other rules

            return results;
        }
    }
}
