// <copyright file="User.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// User.
/// </summary>
/// <seealso cref="DomainModel.Entity.BaseEntity" />
public class User : BaseEntity
{
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>
    /// The email.
    /// </value>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    /// <value>
    /// The username.
    /// </value>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    /// <value>
    /// The phone number.
    /// </value>
    [Required]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>
    /// The address.
    /// </value>
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    /// <value>
    /// The products.
    /// </value>
    public virtual IList<Product> Products { get; set; } = new List<Product>();

    /// <summary>
    /// Gets or sets the offers.
    /// </summary>
    /// <value>
    /// The offers.
    /// </value>
    public virtual IList<Offer> Offers { get; set; } = new List<Offer>();

    /// <summary>
    /// Gets or sets the roles.
    /// </summary>
    /// <value>
    /// The roles.
    /// </value>
    public virtual IList<Role> Roles { get; set; } = new List<Role>();

    /// <summary>
    /// Gets or sets the get scores.
    /// </summary>
    /// <value>
    /// The get scores.
    /// </value>
    public virtual IList<Score> GetScores { get; set; } = new List<Score>();

    /// <summary>
    /// Gets or sets the given scores.
    /// </summary>
    /// <value>
    /// The given scores.
    /// </value>
    public virtual IList<Score> GivenScores { get; set; } = new List<Score>();
}