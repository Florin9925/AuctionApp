using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer.Exception;

namespace ServiceLayer.ServiceImplementation;

public class ScoreServiceImpl : IScoreService
{
    private readonly IScoreDataServices _scoreDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<ScoreServiceImpl> _logger;
    private readonly ScoreDtoValidator _validator;
    private readonly MyConfiguration _myConfiguration;


    public ScoreServiceImpl(
        IScoreDataServices scoreDataServices,
        ILogger<ScoreServiceImpl> logger,
        IUserDataServices userDataServices,
        ScoreDtoValidator validator,
        IOptions<MyConfiguration> myConfiguration)
    {
        _scoreDataServices = scoreDataServices;
        _logger = logger;
        _userDataServices = userDataServices;
        _validator = validator;
        _myConfiguration = myConfiguration.Value;
    }

    public IList<ScoreDto> GetAll()
    {
        _logger.LogInformation("Getting all scores");
        return _scoreDataServices.GetAll().Select(s => new ScoreDto(s)).ToList();
    }

    public void DeleteById(int id)
    {
        _logger.LogInformation("Deleting score with id {0}", id);
        var score = _scoreDataServices.GetById(id);
        if (score == null)
        {
            throw new NotFoundException<ScoreDto>(id, _logger);
        }

        _scoreDataServices.Delete(score);
    }

    public ScoreDto Update(ScoreDto dto)
    {
        _logger.LogInformation("Updating score with id {0}", dto.Id);

        _validator.ValidateAndThrow(dto);

        var score = _scoreDataServices.GetById(dto.Id);
        if (score == null)
        {
            throw new NotFoundException<ScoreDto>(dto, _logger);
        }

        score.Value = dto.Value;

        return new ScoreDto(_scoreDataServices.Update(score));
    }

    public ScoreDto GetById(int id)
    {
        _logger.LogInformation("Getting score with id {0}", id);
        var score = _scoreDataServices.GetById(id);
        if (score == null)
        {
            throw new NotFoundException<ScoreDto>(id, _logger);
        }

        return new ScoreDto(score);
    }

    public ScoreDto Insert(ScoreDto dto)
    {
        _logger.LogInformation("Inserting score with id {0}", dto.Id);

        _validator.ValidateAndThrow(dto);

        var receiver = _userDataServices.GetById(dto.ReceiverId);
        if (receiver == null)
        {
            throw new NotFoundException<UserDto>(dto.ReceiverId, _logger);
        }

        var reviewer = _userDataServices.GetById(dto.ReviewerId);
        if (reviewer == null)
        {
            throw new NotFoundException<UserDto>(dto.ReviewerId, _logger);
        }

        var score = new Score
        {
            Id = 0,
            Value = dto.Value,
            Reviewer = reviewer,
            ReviewerId = reviewer.Id,
            Receiver = receiver,
            ReceiverId = receiver.Id
        };

        return new ScoreDto(_scoreDataServices.Insert(score));
    }

    public decimal GetUserScore(int userId)
    {
        var score = _scoreDataServices.GetUserScore(userId);

        return score == -1 ? _myConfiguration.S : score;
    }
}