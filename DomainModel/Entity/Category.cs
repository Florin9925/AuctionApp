// <copyright file="Category.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Category.
/// </summary>
/// <seealso cref="DomainModel.Entity.BaseEntity" />
public class Category : BaseEntity
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    /// <value>
    /// The products.
    /// </value>
    public virtual IList<Product> Products { get; set; } = new List<Product>();

    /// <summary>
    /// Gets or sets the child categories.
    /// </summary>
    /// <value>
    /// The child categories.
    /// </value>
    public virtual IList<Category> ChildCategories { get; set; } = new List<Category>();

    /// <summary>
    /// Gets or sets the parent categories.
    /// </summary>
    /// <value>
    /// The parent categories.
    /// </value>
    public virtual IList<Category> ParentCategories { get; set; } = new List<Category>();
}