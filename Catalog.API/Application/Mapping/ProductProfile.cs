using AutoMapper;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.ProductDtos;
using Catalog.API.Domain;

namespace Catalog.API.Application.Mapping
{
    //Product --> ProductDto
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Conversion Logic
            //Fluent API

            CreateMap<Product, ProductDto>();
            CreateMap <CreateProductDto, Product>();
            // CreateMap<CreateProductDto, Product>();
            //  CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }

        
    }
}
