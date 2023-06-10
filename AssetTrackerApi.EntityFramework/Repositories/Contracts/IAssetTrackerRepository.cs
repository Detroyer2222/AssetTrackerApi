namespace AssetTrackerApi.EntityFramework.Repositories.Contracts;

public interface IAssetTrackerRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
    Task<T> GetByIdAsync(int id, CancellationToken ct);
    Task<T> AddAsync(T entity, CancellationToken ct);
    Task<T> UpdateAsync(T entity, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
}