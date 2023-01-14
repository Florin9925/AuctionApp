using DomainModel.Dto;

namespace ServiceLayer;

public interface IScoreService : ICRUDService<ScoreDto>
{
    decimal GetUserScore(int userId);
}