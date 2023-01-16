// <copyright file="PostgresScoreDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper.PostgresDAO;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

/// <summary>
/// PostgresScoreDataServices.
/// </summary>
/// <seealso cref="DataMapper.IScoreDataServices" />
public class PostgresScoreDataServices : IScoreDataServices
{
    private readonly AuctionAppContext context;
    private readonly ScoreValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostgresScoreDataServices"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="validator">The validator.</param>
    public PostgresScoreDataServices(AuctionAppContext context, ScoreValidator validator)
    {
        this.context = context;
        this.validator = validator;
    }

    /// <summary>
    /// Inserts the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>score.</returns>
    public Score Insert(Score entity)
    {
        this.validator.ValidateAndThrow(entity);
        var score = this.context.Add(entity);
        this.context.SaveChanges();
        return score.Entity;
    }

    /// <summary>
    /// Updates the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>score.</returns>
    /// <exception cref="System.ArgumentNullException">srgument null.</exception>
    public Score Update(Score item)
    {
        this.validator.ValidateAndThrow(item);
        var score = this.context.Scores.Find(item.Id);

        ArgumentNullException.ThrowIfNull(score);

        this.context.Entry(score).CurrentValues.SetValues(item);
        this.context.SaveChanges();
        return item;
    }

    /// <summary>
    /// Deletes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public void Delete(Score entity)
    {
        var score = this.context.Scores.Find(entity.Id);
        if (score == null)
        {
            return;
        }

        this.context.Remove(score);
        this.context.SaveChanges();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>score.</returns>
    public Score GetById(object id)
    {
        return this.context.Scores.Find(id);
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of scores.</returns>
    public IList<Score> GetAll()
    {
        return this.context.Scores.ToList();
    }

    /// <summary>
    /// Gets the user score.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>user score.</returns>
    /// <exception cref="System.NotImplementedException">argument null.</exception>
    public decimal GetUserScore(int userId)
    {
        return 0;
    }
}