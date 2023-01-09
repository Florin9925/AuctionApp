using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.Exception;

public class InvalidOfferException : System.Exception
{
    public InvalidOfferException(OfferDto offerDto, ILogger logger) : base($"Invalid offer {offerDto}")
    {
        logger.LogError($"Invalid offer {offerDto}");
    }
}