// <copyright file="ScoreServiceImpl.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.ServiceImplementation;

using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer.Exception;

/// <summary>
/// ScoreServiceImpl.
/// </summary>
/// <seealso cref="ServiceLayer.IScoreService" />
public class ScoreServiceImpl : IScoreService
{
    private readonly IScoreDataServices scoreDataServices;
    private readonly IUserDataServices userDataServices;
    private readonly ILogger<ScoreServiceImpl> logger;
    private readonly ScoreDtoValidator validator;
    private readonly MyConfiguration myConfiguration;

    /// <summary>
    /// Initializes a new instance of the <see cref="ScoreServiceImpl"/> class.
    /// </summary>
    /// <param name="scoreDataServices">The score data services.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="userDataServices">The user data services.</param>
    /// <param name="validator">The validator.</param>
    /// <param name="myConfiguration">My configuration.</param>
    public ScoreServiceImpl(
        IScoreDataServices scoreDataServices,
        ILogger<ScoreServiceImpl> logger,
        IUserDataServices userDataServices,
        ScoreDtoValidator validator,
        IOptions<MyConfiguration> myConfiguration)
    {
        this.scoreDataServices = scoreDataServices;
        this.logger = logger;
        this.userDataServices = userDataServices;
        this.validator = validator;
        this.myConfiguration = myConfiguration.Value;
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of scores.</returns>
    public IList<ScoreDto> GetAll()
    {
        this.logger.LogInformation("Getting all scores");
        return this.scoreDataServices.GetAll().Select(s => new ScoreDto(s)).ToList();
    }

    /// <summary>
    /// Deletes the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <exception cref="NotFoundException&lt;ScoreDto&gt;">not found score.</exception>
    public void DeleteById(int id)
    {
        this.logger.LogInformation("Deleting score with id {0}", id);
        var score = this.scoreDataServices.GetById(id);
        if (score == null)
        {
            throw new NotFoundException<ScoreDto>(id, this.logger);
        }

        this.scoreDataServices.Delete(score);
    }

    /// <summary>
    /// > Update a score by id.
    /// </summary>
    /// <param name="dto">The DTO that will be used to update the score.</param>
    /// <returns>
    /// A ScoreDto object.
    /// </returns>
    public ScoreDto Update(ScoreDto dto)
    {
        this.logger.LogInformation("Updating score with id {0}", dto.Id);

        this.validator.ValidateAndThrow(dto);

        var score = this.scoreDataServices.GetById(dto.Id);
        if (score == null)
        {
            throw new NotFoundException<ScoreDto>(dto, this.logger);
        }

        score.Value = dto.Value;

        return new ScoreDto(this.scoreDataServices.Update(score));
    }

    /// <summary>
    /// > Get a score by id.
    /// </summary>
    /// <param name="id">The id of the score to get.</param>
    /// <returns>
    /// A ScoreDto object.
    /// </returns>
    public ScoreDto GetById(int id)
    {
        this.logger.LogInformation("Getting score with id {0}", id);
        var score = this.scoreDataServices.GetById(id);
        if (score == null)
        {
            throw new NotFoundException<ScoreDto>(id, this.logger);
        }

        return new ScoreDto(score);
    }

    /// <summary>
    /// > Inserts a new score into the database.
    /// </summary>
    /// <param name="dto">The DTO that will be used to create the new score.</param>
    /// <returns>
    /// A ScoreDto object.
    /// </returns>
    public ScoreDto Insert(ScoreDto dto)
    {
        this.logger.LogInformation("Inserting score with id {0}", dto.Id);

        this.validator.ValidateAndThrow(dto);

        var receiver = this.userDataServices.GetById(dto.ReceiverId);
        if (receiver == null)
        {
            throw new NotFoundException<UserDto>(dto.ReceiverId, this.logger);
        }

        var reviewer = this.userDataServices.GetById(dto.ReviewerId);
        if (reviewer == null)
        {
            throw new NotFoundException<UserDto>(dto.ReviewerId, this.logger);
        }

        var score = new Score
        {
            Id = 0,
            Value = dto.Value,
            Reviewer = reviewer,
            ReviewerId = reviewer.Id,
            Receiver = receiver,
            ReceiverId = receiver.Id,
        };

        return new ScoreDto(this.scoreDataServices.Insert(score));
    }

    /// <summary>
    /// > Get the user's score from the database, and if it's -1, return the default score from the configuration file.
    /// </summary>
    /// <param name="userId">The user's id.</param>
    /// <returns>
    /// The user's score.
    /// </returns>
    public decimal GetUserScore(int userId)
    {
        var score = this.scoreDataServices.GetUserScore(userId);

        return score == -1 ? this.myConfiguration.S : score;
    }
}