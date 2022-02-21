using AutoMapper;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.ProductDtos;
using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data.Services.Paging;

namespace Catalog.API.Application.Mapping
{
    //Product --> ProductDto
    public class PagingProfile : Profile
    {
        public PagingProfile()
        {
            //Conversion Logic
            //Fluent API

            CreateMap<SearchRequestDto, PagingParam>();
       
        }

        
    }
}
