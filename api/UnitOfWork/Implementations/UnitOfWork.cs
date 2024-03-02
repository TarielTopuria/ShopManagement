using ProductManagementService.Data;
using ProductManagementService.Repositories.Implementations;
using ProductManagementService.Repositories.Interfaces;
using ProductManagementService.UnitOfWork.Interfaces;

namespace ProductManagementService.UnitOfWork.Implementations
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext context = context;
        public IProductRepository Products { get; private set; } = new ProductRepository(context);
        public IGroupRepository Groups { get; private set; } = new GroupRepository(context);
        public ICountryRepository Countries { get; private set; } = new CountryRepository(context);
        public async Task<int> CommitAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (needs logger implementation)
                throw new Exception($"An error occurred when committing changes: {ex.Message}", ex);
            }
        }

        public async Task SaveAsync() => await context.SaveChangesAsync();
        public void Dispose() => context.Dispose();
    }
}
