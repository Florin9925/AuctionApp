using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer.Exception;

namespace ServiceLayer.ServiceImplementation;

public class OfferServiceImpl : IOfferService
{
    private readonly IOfferDataServices _offerDataServices;
    private readonly IProductDataServices _productDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<OfferServiceImpl> _logger;
    private readonly OfferDtoValidator _validator;
    private readonly MyConfiguration _myConfiguration;

    public OfferServiceImpl(
        IOfferDataServices offerDataServices,
        IProductDataServices productDataServices,
        IUserDataServices userDataServices,
        ILogger<OfferServiceImpl> logger,
        OfferDtoValidator validator,
        IOptions<MyConfiguration> myConfiguration)
    {
        _offerDataServices = offerDataServices;
        _productDataServices = productDataServices;
        _userDataServices = userDataServices;
        _logger = logger;
        _validator = validator;
        _myConfiguration = myConfiguration.Value;
    }

    public IList<OfferDto> GetAll()
    {
        _logger.LogInformation("Get all offers");

        return _offerDataServices.GetAll().Select(o => new OfferDto(o)).ToList();
    }

    public void Delete(OfferDto dto)
    {
        _logger.LogInformation("Delete offer {0}", dto);

        var offer = _offerDataServices.GetById(dto.Id);
        if (offer == null)
        {
            throw new NotFoundException<OfferDto>(dto, _logger);
        }

        _offerDataServices.Delete(offer);
    }

    public OfferDto Update(OfferDto dto)
    {
        throw new NotImplementedException();
    }

    public OfferDto GetById(int id)
    {
        _logger.LogInformation("Get offer by id {0}", id);

        var offer = _offerDataServices.GetById(id);
        if (offer == null)
        {
            throw new NotFoundException<OfferDto>(id, _logger);
        }

        return new OfferDto(offer);
    }

    public OfferDto Insert(OfferDto dto)
    {
        _logger.LogInformation("Insert offer {0}", dto);

        _validator.ValidateAndThrow(dto);

        var lastOffer = _offerDataServices.GetLastProductOffer(dto.ProductId);
        if (lastOffer == null)
        {
            var product = _productDataServices.GetById(dto.ProductId);

            if (dto.Price > product.InitialPrice * 4)
            {
                throw new InvalidDataException<OfferDto>(dto, _logger);
            }
        }
        else
        {
            if (dto.Price > lastOffer.Price * 3)
            {
                throw new InvalidDataException<OfferDto>(dto, _logger);
            }
        }

        var offer = new Offer
        {
            Id = 0,
            Product = _productDataServices.GetById(dto.ProductId),
            Bidder = _userDataServices.GetById(dto.BidderId),
            Price = dto.Price,
        };

        _offerDataServices.Insert(offer);

        return new OfferDto(offer);
    }
}