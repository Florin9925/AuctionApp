using DomainModel.Entity;

namespace DataMapper.PostgresDAO;

public class PostgresProductDataServices : IProductDataServices
{
    private readonly AuctionAppContext _context;

    public PostgresProductDataServices(AuctionAppContext context)
    {
        _context = context;
    }

    void IRepository<Product>.Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    IList<Product> IRepository<Product>.GetAll()
    {
        return _context.Products.ToList();
    }

    Product IRepository<Product>.GetById(object id)
    {
        throw new NotImplementedException();
    }

    Product IRepository<Product>.Insert(Product entity)
    {
        throw new NotImplementedException();
    }

    Product IRepository<Product>.Update(Product item)
    {
        throw new NotImplementedException();
    }
}