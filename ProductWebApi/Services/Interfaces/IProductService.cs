using ProductWebApi.Models;

namespace ProductWebApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<AmcartResponse<Product>> GetProduct(int productId);

        Task<AmcartResponse<ProductSKU>> GetProductSKUs(int productId);

    }
}
