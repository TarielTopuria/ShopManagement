namespace ProductManagementService.Repositories.General
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Query();
        Task<T?> GetByIdAsync(int id);
        Task InsertAsync(T obj);
        void Update(T obj);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
