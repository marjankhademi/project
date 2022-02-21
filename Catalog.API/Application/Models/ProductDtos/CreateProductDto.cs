using Catalog.API.Application.Validation.Product;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Application.Models.ProductDtos
{
    [ProductRule1Validator(ErrorMessage = "Rule1 not passed!")]
    [ProductRule2Validator(ErrorMessage = "Rule2 not passed!")]
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Custom Message1")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Custom Message2")]
        [ProductNameValidator(ErrorMessage = "Invalid Product Name!")]
        public string Name { get; set; }
        [Range(100, 500)]
        public int Price { get; set; }
        //[RegularExpression("URL, EMAIL, IP")]
        public string Description { get; set; }
    }
}

namespace Catalog.API
{
    class CreateProductDto
    {
        public string Name { get; internal set; }
        public int Price { get; internal set; }
    }
}