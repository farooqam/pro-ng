using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStoreApi.DataAccess;

namespace SportsStoreApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await _productRepository.GetProductAsync(id);

            if (product == null) return NotFound();

            return Ok(product);
        }
    }
}