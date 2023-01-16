// <copyright file="PostgresCategoryDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper.PostgresDAO;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

/// <summary>
/// PostgresCategoryDataServices.
/// </summary>
/// <seealso cref="DataMapper.ICategoryDataServices" />
public class PostgresCategoryDataServices : ICategoryDataServices
{
    private readonly AuctionAppContext context;
    private readonly CategoryValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostgresCategoryDataServices"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="validator">The validator.</param>
    public PostgresCategoryDataServices(AuctionAppContext context, CategoryValidator validator)
    {
        this.context = context;
        this.validator = validator;
    }

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void IRepository<Category>.Delete(Category entity)
    {
        var category = this.context.Categories.Find(entity.Id);
        if (category == null)
        {
            return;
        }

        this.context.Remove(category);
        this.context.SaveChanges();
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of categories.</returns>
    IList<Category> IRepository<Category>.GetAll()
    {
        return this.context.Categories.ToList();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>category.</returns>
    /// <exception cref="System.ArgumentNullException">null.</exception>
    Category IRepository<Category>.GetById(object id)
    {
        ArgumentNullException.ThrowIfNull(id);
        return this.context.Categories.Find(id);
    }

    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>category.</returns>
    Category IRepository<Category>.Insert(Category entity)
    {
        this.validator.ValidateAndThrow(entity);
        var category = this.context.Add(entity);
        this.context.SaveChanges();
        return category.Entity;
    }

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>category.</returns>
    /// <exception cref="System.ArgumentNullException">argument null.</exception>
    Category IRepository<Category>.Update(Category item)
    {
        this.validator.ValidateAndThrow(item);
        var entity = this.context.Categories.Find(item.Id);

        ArgumentNullException.ThrowIfNull(entity);

        this.context.Entry(entity).CurrentValues
            .SetValues(item);
        this.context.SaveChanges();
        return item;
    }
}