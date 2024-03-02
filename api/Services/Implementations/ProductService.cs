using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductManagementService.DTOs.ProductDTOs;
using ProductManagementService.Models;
using ProductManagementService.Services.Interfaces;
using ProductManagementService.UnitOfWork.Interfaces;
using ProductManagementService.Validators;

namespace ProductManagementService.Services.Implementations
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IMapper mapper = mapper;

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync()
        {
            try
            {
                var productsQuery = unitOfWork.Products
                                   .Query()
                                   .Include(p => p.Country);

                var products = await productsQuery.ToListAsync();

                return mapper.Map<IEnumerable<ProductResponseDTO>>(products);
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                throw new Exception($"Error occurred in getting all products: {ex.Message}", ex);
            }
        }

        public async Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO product)
        {
            var validator = new ProductRequestDTOValidator();
            var validationResult = await validator.ValidateAsync(product);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            ArgumentNullException.ThrowIfNull(product);

            try
            {
                var productToCreate = mapper.Map<Product>(product);
                await unitOfWork.Products.InsertAsync(productToCreate);
                await unitOfWork.SaveAsync();
                var response = mapper.Map<ProductResponseDTO>(productToCreate);
                return response;
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                throw new Exception($"Error occurred while creating product: {ex.Message}", ex);
            }
        }

        public async Task EditProductAsync(int productId, ProductRequestDTO productUpdateDTO)
        {
            var validator = new ProductRequestDTOValidator();
            var validationResult = await validator.ValidateAsync(productUpdateDTO);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            ArgumentNullException.ThrowIfNull(productUpdateDTO);

            try
            {
                var product = await unitOfWork.Products.GetByIdAsync(productId);
                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with ID {productId} not found.");
                }

                mapper.Map(productUpdateDTO, product);
                unitOfWork.Products.Update(product);
                await unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                throw new Exception($"Error occurred while updating product: {ex.Message}", ex);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            try
            {
                await unitOfWork.Products.DeleteAsync(id);
                await unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework like NLog, Serilog, etc.)
                throw new Exception($"Error occurred while deleting product with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
