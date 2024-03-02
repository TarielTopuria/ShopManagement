using Microsoft.EntityFrameworkCore;
using ProductManagementService.Data;

namespace ProductManagementService.Repositories.General
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        protected readonly DbContext context = context;
        protected readonly DbSet<T> entities = context.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await entities.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception as needed (needs logger implementation)
                throw new Exception($"Error retrieving all instances of {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await entities.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception as needed (needs logger implementation)
                throw new Exception($"Error retrieving instances by Id of {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task InsertAsync(T obj)
        {
            try
            {
                await entities.AddAsync(obj);
            }
            catch (Exception ex)
            {
                // Log the exception as needed (needs logger implementation)
                throw new Exception($"Error adding instance of {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public void Update(T obj)
        {
            try
            {
                context.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                // Log the exception as needed (needs logger implementation)
                throw new Exception($"Error updating instance of {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                T existing = await entities.FindAsync(id);
                if (existing != null)
                {
                    entities.Remove(existing);
                }
            }
            catch (Exception ex)
            {
                // Log the exception as needed (needs logger implementation)
                throw new Exception($"Error deleting instance of {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public IQueryable<T> Query()
        {
            return entities;
        }

        public async Task SaveAsync() => await context.SaveChangesAsync();
    }
}
