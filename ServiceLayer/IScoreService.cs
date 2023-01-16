// <copyright file="IScoreService.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer;

using DomainModel.Dto;

/// <summary>
/// IScoreService.
/// </summary>
/// <seealso cref="ICrudService{T}.Dto.ScoreDto&gt;" />
public interface IScoreService : ICrudService<ScoreDto>
{
    /// <summary>
    /// Gets the user score.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>score value.</returns>
    decimal GetUserScore(int userId);
}