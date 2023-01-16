// <copyright file="Score.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Score.
/// </summary>
/// <seealso cref="DomainModel.Entity.BaseEntity" />
public class Score : BaseEntity
{
    /// <summary>
    /// Gets or sets the reviewer.
    /// </summary>
    /// <value>
    /// The reviewer.
    /// </value>
    [Required]
    public User Reviewer { get; set; }

    /// <summary>
    /// Gets or sets the reviewer identifier.
    /// </summary>
    /// <value>
    /// The reviewer identifier.
    /// </value>
    public int ReviewerId { get; set; }

    /// <summary>
    /// Gets or sets the receiver.
    /// </summary>
    /// <value>
    /// The receiver.
    /// </value>
    [Required]
    public User Receiver { get; set; }

    /// <summary>
    /// Gets or sets the receiver identifier.
    /// </summary>
    /// <value>
    /// The receiver identifier.
    /// </value>
    public int ReceiverId { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    [Required]
    public int Value { get; set; }
}