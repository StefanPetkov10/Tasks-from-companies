using System.Linq.Expressions;

namespace NotesVaultApp.Data.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllAttached();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}
