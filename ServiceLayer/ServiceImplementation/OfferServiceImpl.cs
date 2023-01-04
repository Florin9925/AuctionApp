using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class OfferServiceImpl : IOfferService
{
    private readonly IOfferDataServices _offerDataServices;
    private readonly ILogger _logger;

    public OfferServiceImpl(IOfferDataServices offerDataServices, ILogger<OfferServiceImpl> logger)
    {
        _offerDataServices = offerDataServices;
        _logger = logger;
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