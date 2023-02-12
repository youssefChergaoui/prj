using Artisanale.Web.Models;
using Artisanale.Web.Services.IServices;

namespace Artisanale.Web.Services
{
    public class Productservice : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public Productservice(IHttpClientFactory clientFactory):base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {

            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.ApiType.POST,
                Data = productDto,
                url = SD.ProductApiBase + "/api/products/Create",
               // AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {

            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.ApiType.DELETE,
                url = SD.ProductApiBase + "/api/products/Delete/" + id,
                //AccessToken = token
            });
        }

        public async Task<T> GetAllProductAsync<T>()
        {
          return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.ApiType.GET,
                url = SD.ProductApiBase + "/api/products",
/*                AccessToken = token
*/            
          });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {

            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.ApiType.GET,
                url = SD.ProductApiBase + "/api/products/"+id,
             //   AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apitype = SD.ApiType.PUT,
                Data = productDto,
                url = SD.ProductApiBase + "/api/products/update",
              //  AccessToken = token
            });
        }
    }
}
