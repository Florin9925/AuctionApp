// <copyright file="UserDto.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto;

using DomainModel.Entity;

/// <summary>
/// UserDto.
/// </summary>
/// <seealso cref="DomainModel.Dto.BaseDto" />
public class UserDto : BaseDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserDto"/> class.
    /// </summary>
    public UserDto()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserDto"/> class.
    /// </summary>
    /// <param name="user"> entity. </param>
    public UserDto(User user)
    {
        this.Id = user.Id;
        this.FirstName = user.FirstName;
        this.LastName = user.LastName;
        this.Email = user.Email;
        this.Address = user.Address;
        this.PhoneNumber = user.PhoneNumber;
        this.Username = user.Username;
    }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>
    /// The email.
    /// </value>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>
    /// The address.
    /// </value>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    /// <value>
    /// The phone number.
    /// </value>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    /// <value>
    /// The username.
    /// </value>
    public string Username { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName}";
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return obj is UserDto dto &&
               this.Id == dto.Id &&
               this.FirstName == dto.FirstName &&
               this.LastName == dto.LastName &&
               this.Email == dto.Email &&
               this.Address == dto.Address &&
               this.PhoneNumber == dto.PhoneNumber &&
               this.Username == dto.Username;
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    /// </returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.FirstName, this.LastName, this.Email, this.Address, this.PhoneNumber, this.Username);
    }
}