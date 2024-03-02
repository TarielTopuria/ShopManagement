using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProductManagementService.DTOs.ProductDTOs;
using ProductManagementService.Services.Interfaces;

namespace ProductManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("createProduct")]
        public async Task<ActionResult<ProductResponseDTO>> CreateProduct(ProductRequestDTO product)
        {
            try
            {
                var newProduct = await productService.CreateProductAsync(product);
                return Ok(newProduct);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductRequestDTO productUpdateDTO)
        {
            try
            {
                if (productUpdateDTO == null)
                {
                    return BadRequest("Product update data is null");
                }

                await productService.EditProductAsync(id, productUpdateDTO);

                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await productService.DeleteProductAsync(id);
                return Ok($"Product with ID {id} has been successfully deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
