// <copyright file="ICRUDService.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer;

/// <summary>
/// ICRUDService.
/// </summary>
/// <typeparam name="T">class.</typeparam>
public interface ICrudService<T>
{
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of T.</returns>
    IList<T> GetAll();

    /// <summary>
    /// Deletes a record from the database by its id.
    /// </summary>
    /// <param name="id">The id of the object to delete.</param>
    void DeleteById(int id);

    /// <summary>
    /// > Update the database with the values in the dto.
    /// </summary>
    /// <param name="dto">The value.</param>
    /// <returns>T.</returns>
    T Update(T dto);

    /// <summary>
    /// GetById returns a single object of type T, where T is the type of the object being returned, and the id parameter is
    /// an integer.
    /// </summary>
    /// <param name="id">The id of the entity to get.</param>
    /// <returns>T.</returns>
    T GetById(int id);

    /// <summary>
    /// Inserts a new record into the database.
    /// </summary>
    /// <param name="dto">The value.</param>
    /// <returns>T.</returns>
    T Insert(T dto);
}