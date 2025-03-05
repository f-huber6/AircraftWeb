using System.Linq.Expressions;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repository;

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AircraftContext _context;
    private readonly DbSet<TEntity> _table;
    
    public ARepository(AircraftContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }
    
    public async Task<TEntity> CreateAsync(TEntity t)
    {
        await _table.AddAsync(t);
        await _context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        await _table.AddRangeAsync(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task UpdateAsync(int id, TEntity t)
    {
        var entity = await _table.FindAsync(id);
        _context.Entry(entity!).CurrentValues.SetValues(t);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity t)
    {
        if (t == null)
        {
            throw new ArgumentNullException(nameof(t), "Entity cannot be null");
        }
        _table.Update(t);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        _table.UpdateRange(list);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> ReadAsync(int id) => await _context.Set<TEntity>().FindAsync(id);
    public virtual async Task<List<TEntity>> ReadAsync(int start, int count) => await _context.Set<TEntity>().Skip(start).Take(count).ToListAsync();
    public virtual async Task<List<TEntity>> ReadAllAsync() => await _context.Set<TEntity>().ToListAsync();
    public async Task DeleteAsync(int id, TEntity t)
    {
        var entity = await _table.FindAsync(id);
        _table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _table.FindAsync(id);
        _table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) =>
        await _table.Where(filter).ToListAsync();

    public async Task DeleteAsync(TEntity t)
    {
        if (t == null)
        {
            throw new ArgumentNullException(nameof(t), "Entity cannot be null");
        }

        _table.Remove(t);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(List<TEntity> list)
    {
        _table.RemoveRange(list);
        await _context.SaveChangesAsync();
    }
}