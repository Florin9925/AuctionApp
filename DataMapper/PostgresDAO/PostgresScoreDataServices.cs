using DomainModel.Entity;

namespace DataMapper.PostgresDAO;

public class PostgresScoreDataServices : IScoreDataServices
{
    private readonly AuctionAppContext _context;

    public PostgresScoreDataServices(AuctionAppContext context)
    {
        _context = context;
    }

    public Score Insert(Score entity)
    {
        throw new NotImplementedException();
    }

    public Score Update(Score item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Score entity)
    {
        throw new NotImplementedException();
    }

    public Score GetById(object id)
    {
        throw new NotImplementedException();
    }

    public IList<Score> GetAll()
    {
        return _context.Scores.ToList();
    }
}