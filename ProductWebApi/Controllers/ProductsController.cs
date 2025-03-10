using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Services.Interfaces;

namespace ProductWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;


        [HttpGet]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var results = await _productService.GetProduct(productId);
            return StatusCode((int)results.Status, results);
        }
    }
}
