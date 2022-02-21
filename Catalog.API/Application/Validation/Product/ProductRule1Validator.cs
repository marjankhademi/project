using Catalog.API.Application.Models;
using Catalog.API.Application.Models.ProductDtos;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Application.Validation.Product
{
    public class ProductRule1Validator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            //var createProductDto = value as CreateProductDto;
            var createProductDto = value as CreateProductDto;

            return !(createProductDto.Name == "phone" && createProductDto.Price == 156);
        }
    }
}

  
