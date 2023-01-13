using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.Exception;

public class InvalidDataException<T> : System.Exception
{
    public InvalidDataException(T t, ILogger logger) : base($"Invalid {typeof(T).Name} {t}")
    {
        logger.LogError($"Invalid {typeof(T).Name} {t}");
    }
}