using Artisanale.Services.ProductApi.DbContexts;
using Artisanale.Services.ProductApi.Models.Dto;
using Artisanale.Services.ProductApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Artisanale.Services.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {





        private readonly ApplicationDbContest _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContest db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
          
                Product Product1=_mapper.Map<ProductDto, Product>(productDto);
                Product product = await _db.Products.Where(x => x.ProductId == Product1.ProductId).AsNoTracking().FirstOrDefaultAsync();


            if (Product1.ProductId > 0 && product != null)
                {

                _db.Products.Update(Product1);

            }
            else
                {
                Product1.ProductId=0;
                 _db.Products.Add(Product1);
                
                   

         


            }
            await _db.SaveChangesAsync();

                return _mapper.Map<Product, ProductDto>(Product1);

            
      
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {

            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(productList);

        }
    }
}
