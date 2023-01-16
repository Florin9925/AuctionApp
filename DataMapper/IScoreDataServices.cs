// <copyright file="IScoreDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper;

using DomainModel.Entity;

/// <summary>
/// IScoreDataServices.
/// </summary>
/// <seealso cref="DataMapper.IRepository&lt;DomainModel.Entity.Score&gt;" />
public interface IScoreDataServices : IRepository<Score>
{
    /// <summary>
    /// Gets the user score.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>user score.</returns>
    decimal GetUserScore(int userId);
}