using Artisanale.Web.Models;

namespace Artisanale.Web.Services.IServices
{
    public interface IProductService:IBaseServices
    {
        Task<T> GetAllProductAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto );
        Task<T> UpdateProductAsync<T>(ProductDto productDto);

        Task<T> DeleteProductAsync<T>(int id );

    }
}
