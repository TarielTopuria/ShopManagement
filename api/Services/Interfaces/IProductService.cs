using ProductManagementService.DTOs.ProductDTOs;
using ProductManagementService.Models;

namespace ProductManagementService.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync();
        Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO product);
        Task EditProductAsync(int productId, ProductRequestDTO product);
        Task DeleteProductAsync(int id);
    }
}
