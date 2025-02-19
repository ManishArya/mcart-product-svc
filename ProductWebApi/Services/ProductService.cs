using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using ProductWebApi.Cosmos;
using ProductWebApi.Models;
using ProductWebApi.Services.Interfaces;

namespace ProductWebApi.Services
{
    public class ProductService(ILogger<ProductService> logger, DataAccessClient dataAccessClient, IOptions<DataAccessClientSettings> options) : IProductService
    {
        private readonly ILogger<ProductService> _logger = logger;
        private readonly DataAccessClient _dataAccessClient = dataAccessClient;
        private readonly DataAccessClientSettings _dataAccessClientSettings = options.Value;

        async Task<AmcartResponse<ProductSKU>> IProductService.GetProductSKUs(int productId)
        {
            try
            {
                var amcartResponse = new AmcartResponse<ProductSKU>() { Status = AmcartRequestStatus.BadRequest };
                var results = await _dataAccessClient
                                    .Client
                                     .GetDatabase(_dataAccessClientSettings.DatabaseName).
                                      GetContainer(_dataAccessClientSettings.SkuContainerName)
                                      .ReadItemAsync<ProductSKU>("productId", new PartitionKey());

                if (results.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    amcartResponse.Content = results.Resource;
                    amcartResponse.Status = AmcartRequestStatus.Success;
                }

                return amcartResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                return new AmcartResponse<ProductSKU> { Status = AmcartRequestStatus.InternalServerError };
            }
        }

        async Task<AmcartResponse<Product>> IProductService.GetProduct(int productId)
        {
            try
            {
                var amcartResponse = new AmcartResponse<Product>() { Status = AmcartRequestStatus.BadRequest };

                if(productId <= 0)
                {
                    amcartResponse.Status = AmcartRequestStatus.NotFound;
                    return amcartResponse;
                }

                var results = await _dataAccessClient
                                   .Client
                                    .GetDatabase(_dataAccessClientSettings.DatabaseName).
                                     GetContainer(_dataAccessClientSettings.ProductContainerName)
                                    .ReadItemAsync<Product>(productId.ToString(), new PartitionKey(productId.ToString()));

                amcartResponse.Status = results.StatusCode == System.Net.HttpStatusCode.NotFound ? AmcartRequestStatus.NotFound : AmcartRequestStatus.BadRequest;

                if (results.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    amcartResponse.Content = results.Resource;
                    amcartResponse.Status = AmcartRequestStatus.Success;
                }

                return amcartResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}", ex.Message);
                return new AmcartResponse<Product> { Status = AmcartRequestStatus.InternalServerError };
            }
        }
    }
}
