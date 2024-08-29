using AspireAppSock.ApiService.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspireAppSock.ApiService.Infrastructure.Repositorys;

public class EntityFrameworkRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public EntityFrameworkRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public T GetById(long id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}
