namespace OpenSearchSock.Common.Interfaces;

public interface IGenericRepository<T>
{
    T GetById(long id);
    List<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity); 
}
