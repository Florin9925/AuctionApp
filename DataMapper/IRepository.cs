namespace DataMapper;

public interface IRepository<T>
{
    T Insert(T entity);

    T Update(T item);

    void Delete(T entity);

    T GetById(object id);

    IList<T> GetAll();
}