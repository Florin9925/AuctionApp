// <copyright file="IRepository.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper;

/// <summary>
/// IRepository.
/// </summary>
/// <typeparam name="T">class.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>T.</returns>
    T Insert(T entity);

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>T.</returns>
    T Update(T item);

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    void Delete(T entity);

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>T.</returns>
    T GetById(object id);

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of T.</returns>
    IList<T> GetAll();
}