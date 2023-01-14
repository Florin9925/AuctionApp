using DomainModel.Dto;

namespace ServiceLayer;

public interface IOfferService : ICRUDService<OfferDto>
{
    IList<OfferDto> GetAllProductOffers(int productId);

    OfferDto GetLastProductOffer(int productId);
}