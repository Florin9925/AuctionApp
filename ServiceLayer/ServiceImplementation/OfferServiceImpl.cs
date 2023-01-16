// <copyright file="OfferServiceImpl.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.ServiceImplementation;

using DataMapper;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ServiceLayer.Exception;

/// <summary>
/// OfferServiceImpl.
/// </summary>
/// <seealso cref="ServiceLayer.IOfferService" />
public class OfferServiceImpl : IOfferService
{
    private readonly IOfferDataServices offerDataServices;
    private readonly IProductDataServices productDataServices;
    private readonly IUserDataServices userDataServices;
    private readonly ILogger<OfferServiceImpl> logger;
    private readonly OfferDtoValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="OfferServiceImpl"/> class.
    /// </summary>
    /// <param name="offerDataServices">The offer data services.</param>
    /// <param name="productDataServices">The product data services.</param>
    /// <param name="userDataServices">The user data services.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="validator">The validator.</param>
    public OfferServiceImpl(
        IOfferDataServices offerDataServices,
        IProductDataServices productDataServices,
        IUserDataServices userDataServices,
        ILogger<OfferServiceImpl> logger,
        OfferDtoValidator validator)
    {
        this.offerDataServices = offerDataServices;
        this.productDataServices = productDataServices;
        this.userDataServices = userDataServices;
        this.logger = logger;
        this.validator = validator;
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of offers.</returns>
    public IList<OfferDto> GetAll()
    {
        this.logger.LogInformation("Get all offers");

        return this.offerDataServices.GetAll().Select(o => new OfferDto(o)).ToList();
    }

    /// <summary>
    /// Deletes the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <exception cref="NotFoundException&lt;OfferDto&gt;">not found.</exception>
    public void DeleteById(int id)
    {
        this.logger.LogInformation("Delete offer {0}", id);

        var offer = this.offerDataServices.GetById(id);
        if (offer == null)
        {
            throw new NotFoundException<OfferDto>(id, this.logger);
        }

        this.offerDataServices.Delete(offer);
    }

    /// <summary>
    /// Updates the specified dto.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns>offer.</returns>
    /// <exception cref="System.NotImplementedException"> not implemented.</exception>
    [Obsolete("Method not allowed")]
    public OfferDto Update(OfferDto dto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>offer.</returns>
    /// <exception cref="NotFoundException&lt;OfferDto&gt;">not found.</exception>
    public OfferDto GetById(int id)
    {
        this.logger.LogInformation("Get offer by id {0}", id);

        var offer = this.offerDataServices.GetById(id);
        if (offer == null)
        {
            throw new NotFoundException<OfferDto>(id, this.logger);
        }

        return new OfferDto(offer);
    }

    /// <summary>
    /// Gets all product offers.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <returns>list offer.</returns>
    public IList<OfferDto> GetAllProductOffers(int productId)
    {
        this.logger.LogInformation("Get all offers for product {0}", productId);

        return this.offerDataServices
            .GetAllProductOffers(productId)
            .Select(x => new OfferDto(x))
            .ToList();
    }

    /// <summary>
    /// Gets the last product offer.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <returns>offer.</returns>
    /// <exception cref="NotFoundException&lt;ProductDto&gt;">not found.</exception>
    public OfferDto GetLastProductOffer(int productId)
    {
        this.logger.LogInformation("Get last offer for product {0}", productId);

        var product = this.productDataServices.GetById(productId);

        if (product == null)
        {
            throw new NotFoundException<ProductDto>(productId, this.logger);
        }

        var offer = this.offerDataServices.GetLastProductOffer(productId);

        return offer != null ? new OfferDto(offer) : null;
    }

    /// <summary>
    /// Inserts the specified dto.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns>offer.</returns>
    /// <exception cref="NotFoundException&lt;ProductDto&gt;">not found product.</exception>
    /// <exception cref="NotFoundException&lt;UserDto&gt;">not found user.</exception>
    public OfferDto Insert(OfferDto dto)
    {
        this.logger.LogInformation("Insert offer {0}", dto);

        this.validator.ValidateAndThrow(dto);

        var product = this.productDataServices.GetById(dto.ProductId);
        if (product == null)
        {
            throw new NotFoundException<ProductDto>(dto.ProductId, this.logger);
        }

        var user = this.userDataServices.GetById(dto.BidderId);
        if (user == null)
        {
            throw new NotFoundException<UserDto>(dto.BidderId, this.logger);
        }

        this.CheckLastOffer(dto, product);

        var offer = new Offer
        {
            Id = 0,
            Product = this.productDataServices.GetById(dto.ProductId),
            Bidder = this.userDataServices.GetById(dto.BidderId),
            DateTime = dto.DateTime,
            Price = dto.Price,
        };

        return new OfferDto(this.offerDataServices.Insert(offer));
    }

    /// <summary>
    /// Checks the last offer.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <param name="product">The product.</param>
    /// <exception cref="InvalidDataException&lt;OfferDto&gt;">invalid data.</exception>
    private void CheckLastOffer(OfferDto dto, Product product)
    {
        var lastOffer = this.offerDataServices.GetLastProductOffer(dto.ProductId);
        if (lastOffer == null)
        {
            if (dto.Price > product.InitialPrice * 4 || dto.Price < product.InitialPrice)
            {
                throw new InvalidDataException<OfferDto>(dto, this.logger);
            }
        }
        else
        {
            if (dto.Price > lastOffer.Price * 4 || dto.Price < lastOffer.Price)
            {
                throw new InvalidDataException<OfferDto>(dto, this.logger);
            }
        }
    }
}