// <copyright file="PostgresRoleDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper.PostgresDAO;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

/// <summary>
/// PostgresRoleDataServices.
/// </summary>
/// <seealso cref="DataMapper.IRoleDataServices" />
public class PostgresRoleDataServices : IRoleDataServices
{
    private readonly AuctionAppContext context;
    private readonly RoleValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostgresRoleDataServices"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="validator">The validator.</param>
    public PostgresRoleDataServices(AuctionAppContext context, RoleValidator validator)
    {
        this.context = context;
        this.validator = validator;
    }

    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>role.</returns>
    public Role Insert(Role entity)
    {
        this.validator.ValidateAndThrow(entity);
        var role = this.context.Add(entity);
        this.context.SaveChanges();
        return role.Entity;
    }

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>role.</returns>
    /// <exception cref="System.ArgumentNullException">argument null.</exception>
    public Role Update(Role item)
    {
        this.validator.ValidateAndThrow(item);

        var role = this.context.Roles.Find(item.Id);

        ArgumentNullException.ThrowIfNull(role);

        this.context.Entry(role).CurrentValues.SetValues(item);
        this.context.SaveChanges();
        return item;
    }

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public void Delete(Role entity)
    {
        var role = this.context.Roles.Find(entity.Id);
        if (role == null)
        {
            return;
        }

        this.context.Remove(role);
        this.context.SaveChanges();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>role.</returns>
    public Role GetById(object id)
    {
        return this.context.Roles.Find(id);
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of roles.</returns>
    public IList<Role> GetAll()
    {
        return this.context.Roles.ToList();
    }
}