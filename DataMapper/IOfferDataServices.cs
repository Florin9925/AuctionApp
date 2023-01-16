// <copyright file="IOfferDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper;

using DomainModel.Entity;

/// <summary>
/// IOfferDataServices.
/// </summary>
/// <seealso cref="DataMapper.IRepository&lt;DomainModel.Entity.Offer&gt;" />
public interface IOfferDataServices : IRepository<Offer>
{
    /// <summary>
    /// Gets the last product offer.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <returns>offer.</returns>
    Offer GetLastProductOffer(int productId);

    /// <summary>
    /// Gets all product offers.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <returns>list of offers.</returns>
    IList<Offer> GetAllProductOffers(int productId);
}