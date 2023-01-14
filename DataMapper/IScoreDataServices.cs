using DomainModel.Entity;

namespace DataMapper;

public interface IScoreDataServices : IRepository<Score>
{
    decimal GetUserScore(int userId);
}