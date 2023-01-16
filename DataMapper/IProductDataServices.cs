// <copyright file="IProductDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper;

using DomainModel.Entity;

/// <summary>
/// IProductDataServices.
/// </summary>
/// <seealso cref="DataMapper.IRepository&lt;DomainModel.Entity.Product&gt;" />
public interface IProductDataServices : IRepository<Product>
{
    /// <summary>
    /// Gets the user product descriptions.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>enumeration of description.</returns>
    IEnumerable<string> GetUserProductDescriptions(int userId);

    /// <summary>
    /// Gets the active user products count.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>active products.</returns>
    int GetActiveUserProductsCount(int userId);
}