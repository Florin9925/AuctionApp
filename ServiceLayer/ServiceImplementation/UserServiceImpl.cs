// <copyright file="UserServiceImpl.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.ServiceImplementation;

using DataMapper;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ServiceLayer.Exception;

/// <summary>
/// UserServiceImpl.
/// </summary>
/// <seealso cref="ServiceLayer.IUserService" />
public class UserServiceImpl : IUserService
{
    private readonly IUserDataServices userAccountDataServices;
    private readonly ILogger<UserServiceImpl> logger;
    private readonly UserDtoValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserServiceImpl"/> class.
    /// </summary>
    /// <param name="userAccountDataServices">The user account data services.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="validator">The validator.</param>
    public UserServiceImpl(
        IUserDataServices userAccountDataServices,
        ILogger<UserServiceImpl> logger,
        UserDtoValidator validator)
    {
        this.userAccountDataServices = userAccountDataServices;
        this.logger = logger;
        this.validator = validator;
    }

    /// <summary>
    /// > Delete the user with the given id.
    /// </summary>
    /// <param name="id">The id of the user to delete.</param>
    void ICrudService<UserDto>.DeleteById(int id)
    {
        this.logger.LogInformation("Delete user with id {0}", id);

        var user = this.userAccountDataServices.GetById(id);
        if (user == null)
        {
            throw new NotFoundException<UserDto>(id, this.logger);
        }

        this.userAccountDataServices.Delete(user);
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of users.</returns>
    IList<UserDto> ICrudService<UserDto>.GetAll()
    {
        this.logger.LogInformation("Get all users");
        var users = this.userAccountDataServices.GetAll();

        return users.Select(user => new UserDto(user)).ToList();
    }

    /// <summary>
    /// > Get the user with the specified id, or throw a NotFoundException if the user doesn't exist.
    /// </summary>
    /// <param name="id">The id of the user to get.</param>
    /// <returns>
    /// A UserDto object.
    /// </returns>
    UserDto ICrudService<UserDto>.GetById(int id)
    {
        this.logger.LogInformation("Get user with id {0}", id);

        var user = this.userAccountDataServices.GetById(id);
        if (user == null)
        {
            throw new NotFoundException<UserDto>(id, this.logger);
        }

        return new UserDto(user);
    }

    /// <summary>
    /// > The function takes a UserDto object, validates it, and then inserts it into the database.
    /// </summary>
    /// <param name="dto">The type of the object that will be passed in.</param>
    /// <returns>
    /// A new UserDto object is being returned.
    /// </returns>
    UserDto ICrudService<UserDto>.Insert(UserDto dto)
    {
        this.logger.LogInformation("Insert user {0}", dto);
        this.validator.ValidateAndThrow(dto);

        var user = new User
        {
            Id = 0,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Username = dto.Username,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
        };

        return new UserDto(this.userAccountDataServices.Insert(user));
    }

    /// <summary>
    /// > Update a user in the database.
    /// </summary>
    /// <param name="dto">The type of the object that will be returned by the service.</param>
    /// <returns>
    /// A UserDto object.
    /// </returns>
    UserDto ICrudService<UserDto>.Update(UserDto dto)
    {
        this.logger.LogInformation("Update user {0}", dto);
        this.validator.ValidateAndThrow(dto);

        var user = this.userAccountDataServices.GetById(dto.Id);
        if (user == null)
        {
            throw new NotFoundException<UserDto>(dto, this.logger);
        }

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.Username = dto.Username;
        user.Address = dto.Address;
        user.PhoneNumber = dto.PhoneNumber;

        return new UserDto(this.userAccountDataServices.Update(user));
    }
}