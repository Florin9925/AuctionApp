using DomainModel.Entity;

namespace DataMapper;

public interface IOfferDataServices : IRepository<Offer>
{
    Offer GetLastProductOffer(int productId);
}