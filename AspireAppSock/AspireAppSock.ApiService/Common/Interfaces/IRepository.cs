namespace AspireAppSock.ApiService.Common.Interfaces;

public interface IRepository<T>
{
    T GetById(long id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity); 
}
