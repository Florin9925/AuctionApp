using DataMapper;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ServiceLayer.Exception;

namespace ServiceLayer.ServiceImplementation;

public class OfferServiceImpl : IOfferService
{
    private readonly IOfferDataServices _offerDataServices;
    private readonly IProductDataServices _productDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<OfferServiceImpl> _logger;
    private readonly OfferDtoValidator _validator;

    public OfferServiceImpl(
        IOfferDataServices offerDataServices,
        IProductDataServices productDataServices,
        IUserDataServices userDataServices,
        ILogger<OfferServiceImpl> logger,
        OfferDtoValidator validator)
    {
        _offerDataServices = offerDataServices;
        _productDataServices = productDataServices;
        _userDataServices = userDataServices;
        _logger = logger;
        _validator = validator;
    }

    public IList<OfferDto> GetAll()
    {
        _logger.LogInformation("Get all offers");

        return _offerDataServices.GetAll().Select(o => new OfferDto(o)).ToList();
    }

    public void DeleteById(int id)
    {
        _logger.LogInformation("Delete offer {0}", id);

        var offer = _offerDataServices.GetById(id);
        if (offer == null)
        {
            throw new NotFoundException<OfferDto>(id, _logger);
        }

        _offerDataServices.Delete(offer);
    }

    [Obsolete("Method not allowed")]
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

    public IList<OfferDto> GetAllProductOffers(int productId)
    {
        _logger.LogInformation("Get all offers for product {0}", productId);

        return _offerDataServices
            .GetAllProductOffers(productId)
            .Select(x => new OfferDto(x))
            .ToList();
    }

    public OfferDto GetLastProductOffer(int productId)
    {
        _logger.LogInformation("Get last offer for product {0}", productId);

        var product = _productDataServices.GetById(productId);

        if (product == null)
        {
            throw new NotFoundException<ProductDto>(productId, _logger);
        }

        var offer = _offerDataServices.GetLastProductOffer(productId);

        return offer != null ? new OfferDto(offer) : null;
    }

    public OfferDto Insert(OfferDto dto)
    {
        _logger.LogInformation("Insert offer {0}", dto);

        _validator.ValidateAndThrow(dto);

        var product = _productDataServices.GetById(dto.ProductId);
        if (product == null)
        {
            throw new NotFoundException<ProductDto>(dto.ProductId, _logger);
        }

        var user = _userDataServices.GetById(dto.BidderId);
        if (user == null)
        {
            throw new NotFoundException<UserDto>(dto.BidderId, _logger);
        }

        CheckLastOffer(dto, product);

        var offer = new Offer
        {
            Id = 0,
            Product = _productDataServices.GetById(dto.ProductId),
            Bidder = _userDataServices.GetById(dto.BidderId),
            DateTime = dto.DateTime,
            Price = dto.Price,
        };

        return new OfferDto(_offerDataServices.Insert(offer));
    }

    private void CheckLastOffer(OfferDto dto, Product product)
    {
        var lastOffer = _offerDataServices.GetLastProductOffer(dto.ProductId);
        if (lastOffer == null)
        {
            if (dto.Price > product.InitialPrice * 4 || dto.Price < product.InitialPrice)
            {
                throw new InvalidDataException<OfferDto>(dto, _logger);
            }
        }
        else
        {
            if (dto.Price > lastOffer.Price * 4 || dto.Price < lastOffer.Price)
            {
                throw new InvalidDataException<OfferDto>(dto, _logger);
            }
        }
    }
}