namespace ServiceLayer;

public interface ICRUDService<T>
{
    IList<T> GetAll();

    void DeleteById(int id);

    T Update(T dto);

    T GetById(int id);

    T Insert(T dto);
}