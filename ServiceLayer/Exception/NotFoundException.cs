using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.Exception;

public class NotFoundException<T> : System.Exception
{
    public NotFoundException(T t, ILogger logger) : base($"Not found {typeof(T).Name} {t}")
    {
        logger.LogError($"Not found {typeof(T).Name} {t}");
    }

    public NotFoundException(int id, ILogger logger) : base($"Not found {typeof(T).Name} id: {id}")
    {
        logger.LogError($"Not found {typeof(T).Name} id: {id}");
    }
}