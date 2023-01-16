using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

namespace DataMapper.PostgresDAO;

public class PostgresScoreDataServices : IScoreDataServices
{
    private readonly AuctionAppContext _context;
    private readonly ScoreValidator _validator;

    public PostgresScoreDataServices(AuctionAppContext context, ScoreValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    public Score Insert(Score entity)
    {
        _validator.ValidateAndThrow(entity);
        var score = _context.Add(entity);
        _context.SaveChanges();
        return score.Entity;
    }

    public Score Update(Score item)
    {
        _validator.ValidateAndThrow(item);
        var score = _context.Scores.Find(item.Id);

        ArgumentNullException.ThrowIfNull(score);

        _context.Entry(score).CurrentValues.SetValues(item);
        _context.SaveChanges();
        return item;
    }

    public void Delete(Score entity)
    {
        var score = _context.Scores.Find(entity.Id);
        if (score == null)
            return;
        _context.Remove(score);
        _context.SaveChanges();
    }

    public Score GetById(object id)
    {
        return _context.Scores.Find(id);
    }

    public IList<Score> GetAll()
    {
        return _context.Scores.ToList();
    }

    public decimal GetUserScore(int userId)
    {
        throw new NotImplementedException();
    }
}