// <copyright file="OfferDto.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto;

using DomainModel.Entity;
using FluentValidation;

/// <summary>
/// OfferDto.
/// </summary>
/// <seealso cref="DomainModel.Dto.BaseDto" />
public class OfferDto : BaseDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfferDto"/> class.
    /// </summary>
    public OfferDto()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OfferDto"/> class.
    /// </summary>
    /// <param name="offer"> Offer entity.</param>
    public OfferDto(Offer offer)
    {
        this.Id = offer.Id;
        this.ProductId = offer.Product.Id;
        this.Price = offer.Price;
        this.BidderId = offer.Bidder.Id;
        this.DateTime = offer.DateTime;
    }

    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    /// <value>
    /// The product identifier.
    /// </value>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>
    /// The price.
    /// </value>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the bidder identifier.
    /// </summary>
    /// <value>
    /// The bidder identifier.
    /// </value>
    public int BidderId { get; set; }

    /// <summary>
    /// Gets or sets the date time.
    /// </summary>
    /// <value>
    /// The date time.
    /// </value>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"OfferDto: Id={this.Id}, ProductId={this.ProductId}, Price={this.Price}, BidderId={this.BidderId}, DateTime={this.DateTime}";
    }

    /// <summary>
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object obj)
    {
        return obj is OfferDto dto &&
               this.Id == dto.Id &&
               this.ProductId == dto.ProductId &&
               this.Price == dto.Price &&
               this.BidderId == dto.BidderId;
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    /// </returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.ProductId, this.Price, this.BidderId, this.DateTime);
    }
}