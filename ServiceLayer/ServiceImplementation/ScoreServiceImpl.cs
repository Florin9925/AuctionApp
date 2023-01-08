using DataMapper;
using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class ScoreServiceImpl : IScoreService
{
    private readonly IScoreDataServices _scoreDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<ScoreServiceImpl> _logger;

    public ScoreServiceImpl(
        IScoreDataServices scoreDataServices,
        ILogger<ScoreServiceImpl> logger,
        IUserDataServices userDataServices)
    {
        _scoreDataServices = scoreDataServices;
        _logger = logger;
        _userDataServices = userDataServices;
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