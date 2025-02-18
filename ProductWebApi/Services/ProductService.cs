using Microsoft.Extensions.Logging;
using ProductWebApi.Cosmos;
using ProductWebApi.Models;
using ProductWebApi.Services.Interfaces;

namespace ProductWebApi.Services
{
    public class ProductService(ILogger<ProductService> logger, CosmosService cosmosService) : IProductService
    {
        private readonly ILogger<ProductService> _logger = logger;
        private readonly CosmosService _cosmosService  = cosmosService;

        async Task<AmcartResponse<List<ProductSKU>>> IProductService.GetProductSKUs(int productId)
        {
            try
            {
                var results = await _cosmosService.container.ReadItemAsync<ProductSKU>("productId", new Microsoft.Azure.Cosmos.PartitionKey());
                return new AmcartResponse<List<ProductSKU>>();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                return new AmcartResponse<List<ProductSKU>> { Status = AmcartRequestStatus.InternalServerError };
            }
        }

        async Task<AmcartResponse<Product>> IProductService.GetProduct(int productId)
        {
            try
            {
              var results =  await _cosmosService.container.ReadItemAsync<ProductSKU>("productId", new Microsoft.Azure.Cosmos.PartitionKey());

                if(results.StatusCode == System.Net.HttpStatusCode.OK) 
                {

                }
                return new AmcartResponse<Product>()    ;
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                return new AmcartResponse<Product> { Status = AmcartRequestStatus.InternalServerError };
            }
        }
    }
}
