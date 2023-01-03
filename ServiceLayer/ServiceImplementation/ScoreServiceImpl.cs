using DataMapper;
using DomainModel.DTO;
using DomainModel.Entity;

namespace ServiceLayer.ServiceImplementation;

public class ScoreServiceImpl : IScoreService
{
    private readonly IScoreDataServices _scoreDataServices;

    public ScoreServiceImpl(IScoreDataServices scoreDataServices)
    {
        _scoreDataServices = scoreDataServices;
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