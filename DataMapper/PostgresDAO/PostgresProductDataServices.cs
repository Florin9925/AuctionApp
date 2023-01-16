using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation;

namespace DataMapper.PostgresDAO;

public class PostgresProductDataServices : IProductDataServices
{
    private readonly AuctionAppContext _context;
    private readonly ProductValidator _validator;

    public PostgresProductDataServices(AuctionAppContext context, ProductValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    void IRepository<Product>.Delete(Product entity)
    {
        var product = _context.Products.Find(entity.Id);
        if (product == null)
            return;

        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    IList<Product> IRepository<Product>.GetAll()
    {
        return _context.Products.ToList();
    }

    public IEnumerable<string> GetUserProductDescriptions(int userId)
    {
        return _context.Products
            .Where(p => p.Owner.Id == userId)
            .Select(p => p.Description)
            .ToList();
    }

    public int GetActiveUserProductsCount(int userId)
    {
        return _context.Products
            .Count(p => p.Owner.Id == userId && (!p.IsCompleted && p.EndDate > DateTime.Now));
    }

    Product IRepository<Product>.GetById(object id)
    {
        return _context.Products.Find(id);
    }

    Product IRepository<Product>.Insert(Product entity)
    {
        _validator.ValidateAndThrow(entity);
        var product = _context.Add(entity);
        _context.SaveChanges();
        return product.Entity;
    }

    Product IRepository<Product>.Update(Product item)
    {
        _validator.ValidateAndThrow(item);
        var product = _context.Products.Find(item.Id);

        ArgumentNullException.ThrowIfNull(product);

        _context.Entry(product).CurrentValues.SetValues(item);
        _context.SaveChanges();
        return product;
    }
}