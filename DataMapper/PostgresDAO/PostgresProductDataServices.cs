// <copyright file="PostgresProductDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper.PostgresDAO;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

/// <summary>
/// PostgresProductDataServices.
/// </summary>
/// <seealso cref="DataMapper.IProductDataServices" />
public class PostgresProductDataServices : IProductDataServices
{
    private readonly AuctionAppContext context;
    private readonly ProductValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostgresProductDataServices"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="validator">The validator.</param>
    public PostgresProductDataServices(AuctionAppContext context, ProductValidator validator)
    {
        this.context = context;
        this.validator = validator;
    }

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void IRepository<Product>.Delete(Product entity)
    {
        var product = this.context.Products.Find(entity.Id);
        if (product == null)
        {
            return;
        }

        this.context.Products.Remove(product);
        this.context.SaveChanges();
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of products.</returns>
    IList<Product> IRepository<Product>.GetAll()
    {
        return this.context.Products.ToList();
    }

    /// <summary>
    /// Gets the user product descriptions.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>list of descriptions.</returns>
    public IEnumerable<string> GetUserProductDescriptions(int userId)
    {
        return this.context.Products
            .Where(p => p.Owner.Id == userId)
            .Select(p => p.Description)
            .ToList();
    }

    /// <summary>
    /// Gets the active user products count.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>active products.</returns>
    public int GetActiveUserProductsCount(int userId)
    {
        return this.context.Products
            .Count(p => p.Owner.Id == userId && (!p.IsCompleted && p.EndDate > DateTime.Now));
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>product.</returns>
    Product IRepository<Product>.GetById(object id)
    {
        return this.context.Products.Find(id);
    }

    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>product.</returns>
    Product IRepository<Product>.Insert(Product entity)
    {
        this.validator.ValidateAndThrow(entity);
        var product = this.context.Add(entity);
        this.context.SaveChanges();
        return product.Entity;
    }

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>product.</returns>
    /// <exception cref="System.ArgumentNullException">argument null.</exception>
    Product IRepository<Product>.Update(Product item)
    {
        this.validator.ValidateAndThrow(item);
        var product = this.context.Products.Find(item.Id);

        ArgumentNullException.ThrowIfNull(product);

        this.context.Entry(product).CurrentValues.SetValues(item);
        this.context.SaveChanges();
        return product;
    }
}