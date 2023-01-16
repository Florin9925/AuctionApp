// <copyright file="ProductDto.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto;

using DomainModel.Entity;
using DomainModel.Enum;

/// <summary>
/// ProductDto.
/// </summary>
/// <seealso cref="DomainModel.Dto.BaseDto" />
public class ProductDto : BaseDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDto"/> class.
    /// </summary>
    /// <param name="product"> entity. </param>
    public ProductDto(Product product)
    {
        this.Id = product.Id;
        this.Name = product.Name;
        this.Description = product.Description;
        this.StartDate = product.StartDate;
        this.EndDate = product.EndDate;
        this.OwnerId = product.Owner.Id;
        this.Currency = product.Currency;
        this.Amount = product.Amount;
        this.CategoryId = product.Category.Id;
        this.InitialPrice = product.InitialPrice;
        this.IsCompleted = product.IsCompleted;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDto"/> class.
    /// </summary>
    public ProductDto()
    {
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the start date.
    /// </summary>
    /// <value>
    /// The start date.
    /// </value>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date.
    /// </summary>
    /// <value>
    /// The end date.
    /// </value>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the owner identifier.
    /// </summary>
    /// <value>
    /// The owner identifier.
    /// </value>
    public int OwnerId { get; set; }

    /// <summary>
    /// Gets or sets the currency.
    /// </summary>
    /// <value>
    /// The currency.
    /// </value>
    public Currency Currency { get; set; }

    /// <summary>
    /// Gets or sets the category identifier.
    /// </summary>
    /// <value>
    /// The category identifier.
    /// </value>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the amount.
    /// </summary>
    /// <value>
    /// The amount.
    /// </value>
    public int Amount { get; set; }

    /// <summary>
    /// Gets or sets the initial price.
    /// </summary>
    /// <value>
    /// The initial price.
    /// </value>
    public decimal InitialPrice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is completed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is completed; otherwise, <c>false</c>.
    /// </value>
    public bool IsCompleted { get; set; } = false;

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return obj is ProductDto dto &&
               this.Id == dto.Id &&
               this.Name == dto.Name &&
               this.Description == dto.Description &&
               this.StartDate == dto.StartDate &&
               this.EndDate == dto.EndDate &&
               this.OwnerId == dto.OwnerId &&
               this.Currency == dto.Currency &&
               this.CategoryId == dto.CategoryId &&
               this.Amount == dto.Amount &&
               this.InitialPrice == dto.InitialPrice &&
               this.IsCompleted == dto.IsCompleted;
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(
            this.Id,
            this.Name,
            this.Description,
            this.OwnerId,
            this.CategoryId,
            this.Amount,
            this.InitialPrice,
            this.IsCompleted);
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"Id: {this.Id}, Name: {this.Name}, Description: {this.Description}, StartDate: {this.StartDate}, EndDate: {this.EndDate}, OwnerId: {this.OwnerId}, Currency: {this.Currency}, CategoryId: {this.CategoryId}, Amount: {this.Amount}, InitialPrice: {this.InitialPrice}, IsCompleted: {this.IsCompleted}";
    }
}