using DomainModel.Entity;
using FluentValidation;

namespace DataMapper.PostgresDAO;

public class PostgresOfferDataServices : IOfferDataServices
{
    private readonly AuctionAppContext _context;
    private readonly OfferValidator _validator;

    public PostgresOfferDataServices(AuctionAppContext context, OfferValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    public Offer Insert(Offer entity)
    {
        _validator.ValidateAndThrow(entity);

        var offer = _context.Add(entity);
        _context.SaveChanges();
        return offer.Entity;
    }

    public Offer Update(Offer item)
    {
        _validator.ValidateAndThrow(item);
        var entity = _context.Offers.Find(item.Id);

        ArgumentNullException.ThrowIfNull(entity);

        _context.Entry(entity).CurrentValues
            .SetValues(item);
        _context.SaveChanges();
        return item;
    }

    public void Delete(Offer entity)
    {
        var offer = _context.Offers.Find(entity.Id);
        if (offer == null)
            return;

        _context.Remove(offer);
        _context.SaveChanges();
    }

    public Offer GetById(object id)
    {
        return _context.Offers.Find(id);
    }

    public IList<Offer> GetAll()
    {
        return _context.Offers.ToList();
    }

    public Offer GetLastProductOffer(int productId)
    {
        return _context.Offers
            .Where(o => o.Product.Id == productId)
            .OrderBy(o => o.DateTime)
            .LastOrDefault();
    }

    public IList<Offer> GetAllProductOffers(int productId)
    {
        return _context.Offers
            .Where(o => o.Product.Id == productId)
            .OrderBy(o => o.DateTime)
            .ToList();
    }
}