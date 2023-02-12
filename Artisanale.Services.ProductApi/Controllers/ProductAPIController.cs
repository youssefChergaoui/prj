using Artisanale.Services.ProductApi.Models;
using Artisanale.Services.ProductApi.Models.Dto;
using Artisanale.Services.ProductApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artisanale.Services.ProductApi.Controllers
{
    [Route("api/Products")]
    public class ProductAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private IProductRepository _productRepository;
        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                   = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {

                   ProductDto productDto = await _productRepository.GetProductById(id);
              //  Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        [Route("update")]

        public async Task<object> put([FromBody] ProductDto productDto)
        {
            try
            {

                ProductDto productD = await _productRepository.CreateUpdateProduct(productDto);

                _response.Result = productD;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }


        [HttpPost]
        [Route("Create")]

        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {

                ProductDto productD = await _productRepository.CreateUpdateProduct(productDto);

                _response.Result = productD;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [HttpDelete]
        [Route("Delete")]


        public async Task<object> Delete(int id)
        {
            try
            {

                Boolean productD = await _productRepository.DeleteProduct(id);

                _response.Result = productD;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        

        }
}
