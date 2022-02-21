using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Application.Validation.Product
{
    //Validate for Product Name
    //Custom Field Validator
    public class ProductNameValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //Validation Logic
            if (value == null)
            {
                return true;
            }

            return value.ToString().ToCharArray().ToList().All(c => char.IsLetter(c));
        }
    }
}
