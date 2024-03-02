using ProductManagementService.Models;
using ProductManagementService.Repositories.General;

namespace ProductManagementService.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        // Add methods specific to Product
    }
}
