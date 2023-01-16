// <copyright file="RoleDto.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto;

using DomainModel.Entity;

/// <summary>
/// RoleDto.
/// </summary>
/// <seealso cref="DomainModel.Dto.BaseDto" />
public class RoleDto : BaseDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleDto"/> class.
    /// </summary>
    /// <param name="role"> entity.</param>
    public RoleDto(Role role)
    {
        this.Id = role.Id;
        this.Name = role.Name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleDto"/> class.
    /// </summary>
    public RoleDto()
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
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object obj)
    {
        return obj is RoleDto role &&
               this.Id == role.Id &&
               this.Name == role.Name;
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    public override int GetHashCode()
    {
        var hashCode = -1509228638;
        hashCode = (hashCode * -1521134295) + this.Id.GetHashCode();
        hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Name);
        return hashCode;
    }
}