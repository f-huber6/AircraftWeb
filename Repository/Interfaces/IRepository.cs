namespace Repository.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity t);

    Task<List<TEntity>> CreateRangeAsync(List<TEntity> list);

    Task UpdateAsync(TEntity t);

    Task UpdateAsync(int id, TEntity t);

    Task UpdateRangeAsync(List<TEntity> list);

    Task<TEntity?> ReadAsync(int id);

    Task<List<TEntity>> ReadAsync(int start, int count);

    Task<List<TEntity>> ReadAllAsync();

    Task DeleteAsync(TEntity t);

    Task DeleteAsync(int id, TEntity t);
    
    Task DeleteRangeAsync(List<TEntity> list);
}