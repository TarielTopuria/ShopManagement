using ProductManagementService.Repositories.Interfaces;

namespace ProductManagementService.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IGroupRepository Groups { get; }
        ICountryRepository Countries { get; }
        Task<int> CommitAsync();
        Task SaveAsync();
    }
}
