using ProductManagementService.Data;
using ProductManagementService.Models;
using ProductManagementService.Repositories.General;
using ProductManagementService.Repositories.Interfaces;

namespace ProductManagementService.Repositories.Implementations
{
    public class ProductRepository(AppDbContext context) : Repository<Product>(context), IProductRepository
    {
        // Implement any Product specific methods here
    }
}
