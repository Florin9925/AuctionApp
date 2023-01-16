// <copyright file="BaseEntity.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// BaseEntity.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    [Key]
    public int Id { get; set; }
}