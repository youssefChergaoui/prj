using Artisanale.Services.ProductApi.Models;
using Artisanale.Services.ProductApi.Models.Dto;
using AutoMapper;

namespace Artisanale.Services.ProductApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {

            var mappingConfig = new MapperConfiguration(config =>

            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            }

                );


            return mappingConfig;



        }
    }
}
