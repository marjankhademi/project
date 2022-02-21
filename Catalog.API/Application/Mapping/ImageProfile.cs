using AutoMapper;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.ImageDtos;
using Catalog.API.Application.Models.ProductDtos;
using Catalog.API.Domain;
using CreateImageDto = Catalog.API.Application.Models.ImageDtos.CreateImageDto;

namespace Catalog.API.Application.Mapping
{
    //Product --> ProductDto
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            //Conversion Logic
            //Fluent API

            CreateMap<Image, ImageDto>();
            CreateMap<CreateImageDto, Image>();
            CreateMap<UpdateImageDto, Image>();
        }
    }
}
