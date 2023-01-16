// <copyright file="PostgresUserDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper.PostgresDAO;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

/// <summary>
/// PostgresUserDataServices.
/// </summary>
/// <seealso cref="DataMapper.IUserDataServices" />
public class PostgresUserDataServices : IUserDataServices
{
    private readonly AuctionAppContext context;
    private readonly UserValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostgresUserDataServices"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="validator">The validator.</param>
    public PostgresUserDataServices(AuctionAppContext context, UserValidator validator)
    {
        this.context = context;
        this.validator = validator;
    }

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void IRepository<User>.Delete(User entity)
    {
        var userAccount = this.context.Users.Find(entity.Id);
        if (userAccount == null)
        {
            return;
        }

        this.context.Users.Remove(userAccount);
        this.context.SaveChanges();
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of users.</returns>
    IList<User> IRepository<User>.GetAll()
    {
        return this.context.Users.ToList();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>user.</returns>
    /// <exception cref="System.ArgumentNullException">argument null.</exception>
    User IRepository<User>.GetById(object id)
    {
        ArgumentNullException.ThrowIfNull(id);
        return this.context.Users.Find(id);
    }

    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>user.</returns>
    User IRepository<User>.Insert(User entity)
    {
        this.validator.ValidateAndThrow(entity);

        var user = this.context.Users.Add(entity);
        this.context.SaveChanges();
        return user.Entity;
    }

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>user.</returns>
    /// <exception cref="System.ArgumentNullException">argument null.</exception>
    User IRepository<User>.Update(User item)
    {
        this.validator.ValidateAndThrow(item);
        var entity = this.context.Users.Find(item.Id);

        ArgumentNullException.ThrowIfNull(entity);

        this.context.Entry(entity).CurrentValues
            .SetValues(item);
        this.context.SaveChanges();
        return item;
    }
}