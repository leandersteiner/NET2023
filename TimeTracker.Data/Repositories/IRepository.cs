namespace TimeTracker.Data.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> FindAsync(int id);
    Task<List<T>> FindAllAsync();

    Task<T> AddAsync(T entity);
    Task AddAllAsync(IEnumerable<T> entities);

    Task<T> UpdateAsync(T entity);
    Task UpdateAllAsync(IEnumerable<T> entities);

    Task<T> DeleteAsync(T entity);
    Task DeleteAllAsync(IEnumerable<T> entities);
}