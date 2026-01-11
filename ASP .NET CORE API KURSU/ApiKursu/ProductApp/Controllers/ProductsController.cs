using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            _logger.LogInformation("Fetching all products");
            // Simulate fetching products from a database or service
            var products = new List<Product> { 
                new Product() 
            {
                Id = 1,
                ProductName = "Sample Product"
            } ,
                  new Product()
            {
                Id = 2,
                ProductName = "Sample Product2"
            } ,
                        new Product()
            {
                Id = 3,
                ProductName = "Sample Product3"
            } ,
            };
            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {
            _logger.LogWarning("Product has been created..");
            return Ok(201);
        }
    }
}
