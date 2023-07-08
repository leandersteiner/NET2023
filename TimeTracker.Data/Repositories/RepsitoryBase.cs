using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.Database;
using TimeTracker.Data.Exceptions;

namespace TimeTracker.Data.Repositories;

public class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly TimeTrackerContext _context;

    public RepositoryBase(TimeTrackerContext context)
    {
        _context = context;
    }

    public async Task<T> FindAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null) throw new NotFoundException("Entity was not found");
        return entity;
    }

    public async Task<List<T>> FindAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        _context.ChangeTracker.TrackGraph(entity,
            node => node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged);
        var item = await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return item.Entity;
    }

    public async Task AddAllAsync(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var item = _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return item.Entity;
    }

    public async Task UpdateAllAsync(IEnumerable<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<T> DeleteAsync(T entity)
    {
        var item = _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return item.Entity;
    }

    public async Task DeleteAllAsync(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}