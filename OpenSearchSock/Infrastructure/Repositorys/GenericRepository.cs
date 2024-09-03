using OpenSearchSock.Common.Interfaces;
using OpenSearchSock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OpenSearchSock.Infrastructure.Repositorys;

public class GenericRepository<T>(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILogger<T> logger) : IGenericRepository<T> where T : class
{
    private readonly ILogger<T> _logger = logger;
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;

    public T GetById(long id)
    {
        var _context = _dbContextFactory.CreateDbContext();

        return _context.Set<T>().Find(id)!;
    }
    public List<T> GetAll()
    {
        _logger.LogInformation($"Add {typeof(T).Name}");
        try
        {
            var context = _dbContextFactory.CreateDbContext();
            IQueryable<T> query = context.Set<T>();
            return query.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return Array.Empty<T>().ToList();
    }

    public void Add(T entity)
    {
        _logger.LogInformation($"Add {typeof(T).Name}");
        try
        {

            var _context = _dbContextFactory.CreateDbContext();
            _context.Set<T>().Add(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public void Update(T entity)
    {
        _logger.LogInformation($"Update {typeof(T).Name}");
        try
        {
            var _context = _dbContextFactory.CreateDbContext();
            _context.Entry(entity).State = EntityState.Modified;
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public void Delete(T entity)
    {
        _logger.LogInformation($"Delete {typeof(T).Name}");
        try
        {
            var _context = _dbContextFactory.CreateDbContext();
            _context.Set<T>().Remove(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }
}
