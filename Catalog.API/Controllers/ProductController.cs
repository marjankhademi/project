using AutoMapper;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.ImageDtos;
using Catalog.API.Application.Models.ProductDtos;
using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data.Repositories.Contracts;
using Catalog.API.Infrastructure.Data.Services.Paging;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using CreateImageDto = Catalog.API.Application.Models.ImageDtos.CreateImageDto;

namespace Catalog.API.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(
            IProductRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        ////////////////////////////////////////////////////////////////////////////////////////


        [HttpGet("querya/byminprice")]
        public async Task<IActionResult> GetProductByPrice([FromQuery] int minprice)
        {
            var products = await _repository.GetByPrice(minprice);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        /////////////////////////////////////////////////////////////////

        [HttpGet("querya/bymaxprice")]
        public async Task<IActionResult> GetProductBymaxPrice([FromQuery] int maxprice)
        {
            var products = await _repository.GetBymaxPrice(maxprice);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        /////////////////////////////////////////////////////////////////
        [HttpGet("querya/byRangeprice")]
        public async Task<IActionResult> GetProductByRangPrice([FromQuery] int maxprice, [FromQuery] int minprice)
        {

            //  var products = await _repository.GetByRangePrice(maxprice, minprice);
            var products = await _repository.GetByQuery(maxprice, minprice);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }
        //////////////////////////////////////////////////////////////////////////////

        [HttpGet("filter")]
        public async Task<IActionResult> GetProductByfilter([FromQuery] string filter)
        {

            //  var products = await _repository.GetByRangePrice(maxprice, minprice);
            var products = await _repository.Filter(filter);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }
        ///////////////////////////////////////////////////////////////////////////////

[HttpGet]
    public async Task<IActionResult> GetProduct([FromQuery] SearchRequestDto request)
       {
            // var paging = new PagingParam
            //  {
            //     PageIndex = request.PageIndex,
            //    PageSize = request.PageSize,
            //  };
         //   var products = await _repository.search(request.SearchText!);
            var paging=_mapper.Map<PagingParam>(request);
          var products = await _repository.search(request.SearchText! , paging,request.sort!);
            Response.Headers.Add("X-TotalCount",products.TotalCount.ToString());
           var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }



        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //    [HttpGet]
        //   public async Task < IActionResult> GetProducts()
        //   {
        ////      var products =  await _repository.GetAll();
        //     var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        //     return Ok(productDtos);
        // }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product =await  _repository.GetById(id);
            if (product != null)
            {
                var productDto = _mapper.Map<ProductDto>(product);
                return Ok(productDto);
            }
            else
            {
                return NotFound($"Id : {id} not found");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] CreateImageDto productDto)
        {
            //1. Data Validation

            var product = _mapper.Map<Product>(productDto);
           await _repository.AddNew(product);

            return Ok(_mapper.Map<ProductDto>(product));
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;
          await  _repository.Update(product);

            return Ok(_mapper.Map<ProductDto>(product));
        }

       ///////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product =await _repository.GetById(id);
            if (product != null)
            {
                //Can Delete (Domain, Data)

              await  _repository.Remove(product);

                return Ok();
            }
            else
            {
                return BadRequest($"Id : {id} not found");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPatch("price/{id}")]
        public async Task<IActionResult> UpdateProductPrice(int id,
            [FromBody] JsonPatchDocument<UpdateProductPriceDto> doc)
        {
            if (doc == null)
            {
                return BadRequest("Invalid Patch!");
            }

            var pricePatch = new UpdateProductPriceDto();

            doc.ApplyTo(pricePatch);

            var product =await _repository.GetById(id);

            product.Price = pricePatch.Price;//Setting

         await  _repository.Update(product);

            return Ok(_mapper.Map<ProductDto>(product));
        }





    }
}
