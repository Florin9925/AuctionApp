using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class OfferServiceImpl : IOfferService
{
    private readonly IOfferDataServices _offerDataServices;
    private readonly IProductDataServices _productDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<OfferServiceImpl> _logger;

    public OfferServiceImpl(
        IOfferDataServices offerDataServices,
        IProductDataServices productDataServices,
        IUserDataServices userDataServices,
        ILogger<OfferServiceImpl> logger)
    {
        _offerDataServices = offerDataServices;
        _productDataServices = productDataServices;
        _userDataServices = userDataServices;
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