using System.Linq.Expressions;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repository;

public class ARepository<TEntity>(AircraftContext context) : IRepository<TEntity> where TEntity : class
{
    public async Task<TEntity> CreateAsync(TEntity t)
    {
        await context.Set<TEntity>().AddAsync(t);
        await context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        await context.Set<TEntity>().AddRangeAsync(list);
        await context.SaveChangesAsync();
        return list;
    }

    public async Task UpdateAsync(TEntity t)
    {
        if (t == null)
        {
            throw new ArgumentNullException(nameof(t), "Entity cannot be null");
        }
        context.Set<TEntity>().Update(t);
        await context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        context.Set<TEntity>().UpdateRange(list);
        await context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> ReadAsync(int id) => await context.Set<TEntity>().FindAsync(id);
    public virtual async Task<List<TEntity>> ReadAsync(int start, int count) => await context.Set<TEntity>().Skip(start).Take(count).ToListAsync();
    public virtual async Task<List<TEntity>> ReadAllAsync() => await context.Set<TEntity>().ToListAsync();
    public virtual async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) =>
        await context.Set<TEntity>().Where(filter).ToListAsync();

    public async Task DeleteAsync(TEntity t)
    {
        if (t == null)
        {
            throw new ArgumentNullException(nameof(t), "Entity cannot be null");
        }

        context.Set<TEntity>().Remove(t);
        await context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(List<TEntity> list)
    {
        context.Set<TEntity>().RemoveRange(list);
        await context.SaveChangesAsync();
    }
}