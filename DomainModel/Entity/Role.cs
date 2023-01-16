// <copyright file="Role.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Role.
/// </summary>
/// <seealso cref="DomainModel.Entity.BaseEntity" />
public class Role : BaseEntity
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [Required]
    [StringLength(500, MinimumLength = 2)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>
    /// The users.
    /// </value>
    public IList<User> Users { get; set; }
}