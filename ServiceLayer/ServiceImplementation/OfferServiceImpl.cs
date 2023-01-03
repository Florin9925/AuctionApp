using DataMapper;
using DomainModel.DTO;
using DomainModel.Entity;

namespace ServiceLayer.ServiceImplementation;

public class OfferServiceImpl : IOfferService
{
    private readonly IOfferDataServices _offerDataServices;

    public OfferServiceImpl(IOfferDataServices offerDataServices)
    {
        _offerDataServices = offerDataServices;
    }

    public IList<OfferDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Delete(OfferDto dto)
    {
        throw new NotImplementedException();
    }

    public OfferDto Update(OfferDto dto)
    {
        throw new NotImplementedException();
    }

    public OfferDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public OfferDto Insert(OfferDto dto)
    {
        throw new NotImplementedException();
    }
}