// <copyright file="IOfferService.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer;

using DomainModel.Dto;

/// <summary>
/// IOfferService.
/// </summary>
/// <seealso cref="ICrudService{T}.Dto.OfferDto&gt;" />
public interface IOfferService : ICrudService<OfferDto>
{
    /// <summary>
    /// Gets all product offers.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <returns>list of offers.</returns>
    IList<OfferDto> GetAllProductOffers(int productId);

    /// <summary>
    /// Gets the last product offer.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <returns>offer.</returns>
    OfferDto GetLastProductOffer(int productId);
}