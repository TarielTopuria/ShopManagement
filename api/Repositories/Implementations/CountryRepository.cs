using ProductManagementService.Data;
using ProductManagementService.Models;
using ProductManagementService.Repositories.General;
using ProductManagementService.Repositories.Interfaces;

namespace ProductManagementService.Repositories.Implementations
{
    public class CountryRepository(AppDbContext context) : Repository<Country>(context), ICountryRepository
    {
        // Implement any country-specific methods here
    }
}
