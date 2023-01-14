using System.Runtime.Serialization;
using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.Exception;

public class ProductDescriptionSimilarException : System.Exception
{
    public ProductDescriptionSimilarException(ILogger logger) : base(
        "Product description is similar to another product")
    {
        logger.LogError("Product description is similar to another product");
    }
}