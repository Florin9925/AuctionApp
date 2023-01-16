// <copyright file="Product.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity;

using System.ComponentModel.DataAnnotations;
using DomainModel.Enum;

/// <summary>
/// Product.
/// </summary>
/// <seealso cref="DomainModel.Entity.BaseEntity" />
public class Product : BaseEntity
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    [Required]
    [StringLength(500, MinimumLength = 2)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the start date.
    /// </summary>
    /// <value>
    /// The start date.
    /// </value>
    [Required]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date.
    /// </summary>
    /// <value>
    /// The end date.
    /// </value>
    [Required]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the owner.
    /// </summary>
    /// <value>
    /// The owner.
    /// </value>
    [Required]
    public User Owner { get; set; }

    /// <summary>
    /// Gets or sets the amount.
    /// </summary>
    /// <value>
    /// The amount.
    /// </value>
    [Required]
    public int Amount { get; set; } = 1;

    /// <summary>
    /// Gets or sets the initial price.
    /// </summary>
    /// <value>
    /// The initial price.
    /// </value>
    [Required]
    public decimal InitialPrice { get; set; } = 0;

    /// <summary>
    /// Gets or sets the currency.
    /// </summary>
    /// <value>
    /// The currency.
    /// </value>
    [Required]
    public Currency Currency { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    /// <value>
    /// The category.
    /// </value>
    [Required]
    public Category Category { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is completed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is completed; otherwise, <c>false</c>.
    /// </value>
    [Required]
    public bool IsCompleted { get; set; } = false;

    /// <summary>
    /// Gets or sets the offers.
    /// </summary>
    /// <value>
    /// The offers.
    /// </value>
    public virtual IList<Offer> Offers { get; set; } = new List<Offer>();
}