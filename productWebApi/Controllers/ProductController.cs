using Microsoft.AspNetCore.Mvc;
using productWebApi.Models.Products;
using productWebApi.Services;

namespace productWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product request)
        {
            try
            {
                await _productService.AddProductAsync(request.Name, request.Price, request.Stock);
                return CreatedAtAction(nameof(GetById), new { id = request.Id }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Product request)
        {
            try
            {
                await _productService.UpdateProductAsync(id, request.Name, request.Price, request.Stock);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/decrease-stock")]
        public async Task<IActionResult> DecreaseStock(Guid id, [FromQuery] int quantity)
        {
            try
            {
                await _productService.DecreaseStockAsync(id, quantity);
                return Ok("Stock disminuido correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/increase-stock")]
        public async Task<IActionResult> IncreaseStock(Guid id, [FromQuery] int quantity)
        {
            try
            {
                await _productService.IncreaseStockAsync(id, quantity);
                return Ok("Stock aumentado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
