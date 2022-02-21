using AutoMapper;
using Catalog.API.Application.Models.ImageDtos;
using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using static System.Net.Mime.MediaTypeNames;

namespace Catalog.API.Controllers
{
    [Route("product/{ProductId}/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly ImageRepository _repository;
        private readonly IMapper _mapper;

        public ImageController(
           ImageRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> getproductImage(int ProductId)
        {
            var images = await _repository.Filter(image => image.ProductId == ProductId);
            var imageDtos = _mapper.Map<IEnumerable<ImageDto>>(images);
            return Ok(imageDtos);
        }
        [HttpPost]
        public async Task<ActionResult> AddNewProductimage(int ProductId, [FromBody] CreateImageDto imageDto)
        {
            //1. Data Validation

            var images = _mapper.Map<Image>(imageDto);
            images.ProductId = ProductId;
            // var product = _mapper.Map<Image>(imageDto);
          await _repository.AddNew(images);
            //return Ok();
        return Ok(_mapper.Map<ImageDto>(images));

        }
        [HttpDelete("{ImageId}")]
        public async Task<IActionResult> deleteProductimage(int ProductId, int ImageId)
        {

            var image = await _repository.GetById(ImageId);
            if (image != null)
            {
                if (image.ProductId != ProductId)
                {
                    return BadRequest("image is invalid");
                }
                //Can Delete (Domain, Data)
                await _repository.Remove(image);
                return Ok();
            }
            else
            {
                return BadRequest($"Id : {ImageId} not found");
            }
        }
        [HttpPut("{ImageId}")]
        public async Task<IActionResult> UpdateProductimage(int ProductId, int ImageId, [FromBody] UpdateImageDto imageDto)
        {
            //1. Data Validation
            var  image= _mapper.Map<Image>(imageDto);
            image.Id = ImageId;
            image.ProductId = ProductId;
            await _repository.Update(image);
            return Ok(_mapper.Map<ImageDto>(image));
        }
    }
}
