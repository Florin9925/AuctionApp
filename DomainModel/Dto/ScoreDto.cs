// <copyright file="ScoreDto.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto;

using DomainModel.Entity;

/// <summary>
/// ScoreDto.
/// </summary>
/// <seealso cref="DomainModel.Dto.BaseDto" />
public class ScoreDto : BaseDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScoreDto"/> class.
    /// </summary>
    public ScoreDto()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ScoreDto"/> class.
    /// </summary>
    /// <param name="score"> entity. </param>
    public ScoreDto(Score score)
    {
        this.Id = score.Id;
        this.ReviewerId = score.Reviewer.Id;
        this.ReceiverId = score.Receiver.Id;
        this.Value = score.Value;
    }

    /// <summary>
    /// Gets or sets the reviewer identifier.
    /// </summary>
    /// <value>
    /// The reviewer identifier.
    /// </value>
    public int ReviewerId { get; set; }

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
    public int Value { get; set; }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return obj is ScoreDto dto &&
               this.Id == dto.Id &&
               this.ReviewerId == dto.ReviewerId &&
               this.ReceiverId == dto.ReceiverId &&
               this.Value == dto.Value;
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.ReviewerId, this.ReceiverId, this.Value);
    }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"ScoreDto{{Id={this.Id}, ReviewerId={this.ReviewerId}, ReceiverId={this.ReceiverId}, Value={this.Value}}}";
    }
}