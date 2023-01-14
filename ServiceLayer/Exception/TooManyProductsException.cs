using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.Exception;

public class TooManyProductsException : System.Exception
{
    public TooManyProductsException(ILogger logger) : base("Too many products")
    {
        logger.LogError("Too many products");
    }
}