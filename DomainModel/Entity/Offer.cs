// <copyright file="Offer.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Offer.
/// </summary>
/// <seealso cref="DomainModel.Entity.BaseEntity" />
public class Offer : BaseEntity
{
    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    /// <value>
    /// The product.
    /// </value>
    [Required]
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    /// <value>
    /// The price.
    /// </value>
    [Required]
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the bidder.
    /// </summary>
    /// <value>
    /// The bidder.
    /// </value>
    [Required]
    public User Bidder { get; set; }

    /// <summary>
    /// Gets or sets the date time.
    /// </summary>
    /// <value>
    /// The date time.
    /// </value>
    [Required]
    public DateTime DateTime { get; set; }
}