using AssetTrackerApi.EntityFramework.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackerApi.EntityFramework.Repositories;

public abstract class AssetTrackerRepository<T> : IAssetTrackerRepository<T> where T : class
{
    protected readonly AssetTrackerContext _context;
    private readonly DbSet<T> _dbSet;

    public AssetTrackerRepository(AssetTrackerContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default(CancellationToken))
    {
        return await _dbSet.ToListAsync(ct);
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
    {
        return await _dbSet.FindAsync(id, ct);
    }

    public virtual async Task<T> AddAsync(T entity, CancellationToken ct = default(CancellationToken))
    {
        await _dbSet.AddAsync(entity, ct);
        await SaveChangesAsync(ct);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken ct = default(CancellationToken))
    {
        _context.Entry(entity).State = EntityState.Modified;
        await SaveChangesAsync(ct);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var entity = await GetByIdAsync(id, ct);
        var result = _dbSet.Remove(entity);
        await SaveChangesAsync(ct);

        if (result.State == EntityState.Deleted)
            return true;

        return false;
    }

    public async Task SaveChangesAsync(CancellationToken ct = default(CancellationToken))
    {
        await _context.SaveChangesAsync(ct);
    }
}