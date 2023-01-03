using DomainModel.Entity;

namespace DataMapper.PostgresDAO;

public class PostgresOfferDataServices : IOfferDataServices
{
    private readonly AuctionAppContext _context;

    public PostgresOfferDataServices(AuctionAppContext context)
    {
        _context = context;
    }
    
    public Offer Insert(Offer entity)
    {
        throw new NotImplementedException();
    }

    public Offer Update(Offer item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Offer entity)
    {
        throw new NotImplementedException();
    }

    public Offer GetById(object id)
    {
        throw new NotImplementedException();
    }

    public IList<Offer> GetAll()
    {
        throw new NotImplementedException();
    }
}