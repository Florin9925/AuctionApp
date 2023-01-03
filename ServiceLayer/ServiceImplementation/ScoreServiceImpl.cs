using DataMapper;
using DomainModel.DTO;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class ScoreServiceImpl : IScoreService
{
    private readonly IScoreDataServices _scoreDataServices;
    private readonly ILogger _logger;

    public ScoreServiceImpl(IScoreDataServices scoreDataServices, ILogger<ScoreServiceImpl> logger)
    {
        _scoreDataServices = scoreDataServices;
        _logger = logger;
    }

    public IList<ScoreDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Delete(ScoreDto dto)
    {
        throw new NotImplementedException();
    }

    public ScoreDto Update(ScoreDto dto)
    {
        throw new NotImplementedException();
    }

    public ScoreDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ScoreDto Insert(ScoreDto dto)
    {
        throw new NotImplementedException();
    }
}