// <copyright file="PostgresOfferDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper.PostgresDAO;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

/// <summary>
/// PostgresOfferDataServices.
/// </summary>
/// <seealso cref="DataMapper.IOfferDataServices" />
public class PostgresOfferDataServices : IOfferDataServices
{
    private readonly AuctionAppContext context;
    private readonly OfferValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostgresOfferDataServices"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="validator">The validator.</param>
    public PostgresOfferDataServices(AuctionAppContext context, OfferValidator validator)
    {
        this.context = context;
        this.validator = validator;
    }

    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Offer.</returns>
    public Offer Insert(Offer entity)
    {
        this.validator.ValidateAndThrow(entity);

        var offer = this.context.Add(entity);
        this.context.SaveChanges();
        return offer.Entity;
    }

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>offer.</returns>
    /// <exception cref="System.ArgumentNullException">null.</exception>
    public Offer Update(Offer item)
    {
        this.validator.ValidateAndThrow(item);
        var entity = this.context.Offers.Find(item.Id);

        ArgumentNullException.ThrowIfNull(entity);

        this.context.Entry(entity).CurrentValues
            .SetValues(item);
        this.context.SaveChanges();
        return item;
    }

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public void Delete(Offer entity)
    {
        var offer = this.context.Offers.Find(entity.Id);
        if (offer == null)
        {
            return;
        }

        this.context.Remove(offer);
        this.context.SaveChanges();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Offer.</returns>
    public Offer GetById(object id)
    {
        return this.context.Offers.Find(id);
    }

    public IList<Offer> GetAll()
    {
        return this.context.Offers.ToList();
    }

    /// <summary>
    /// Gets the last product offer.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <returns>offer.</returns>
    public Offer GetLastProductOffer(int productId)
    {
        return this.context.Offers
            .Where(o => o.Product.Id == productId)
            .OrderBy(o => o.DateTime)
            .LastOrDefault();
    }

    /// <summary>
    /// Gets all product offers.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <returns>list of offers.</returns>
    public IList<Offer> GetAllProductOffers(int productId)
    {
        return this.context.Offers
            .Where(o => o.Product.Id == productId)
            .OrderBy(o => o.DateTime)
            .ToList();
    }
}