using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.Exception;

public class ToManyProductsException : System.Exception
{
    public ToManyProductsException(ILogger logger) : base("Too many products")
    {
        logger.LogError("Too many products");
    }
}