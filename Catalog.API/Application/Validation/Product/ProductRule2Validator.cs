using Catalog.API.Application.Models;
using Catalog.API.Application.Models.ImageDtos;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Application.Validation.Product
{
    public class ProductRule2Validator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var createProductDto = value as CreateProductDto;

            return !(createProductDto.Name == "tablet" && createProductDto.Price == 256);
        }
    }
}
