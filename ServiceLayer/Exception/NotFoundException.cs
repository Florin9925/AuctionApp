using DomainModel.Dto;

namespace ServiceLayer.Exception;

public class NotFoundException<T> : System.Exception
{
    public NotFoundException(T t) : base($"Not found {typeof(T).Name} {t}")
    {
    }

    public NotFoundException(int id) : base($"Not found {typeof(T).Name} id: {id}")
    {
    }
}