using DomainModel.Entity;
using FluentValidation;

namespace DataMapper.PostgresDAO;

public class PostgresUserDataServices : IUserDataServices
{
    private readonly AuctionAppContext _context;
    private readonly UserValidator _validator;

    public PostgresUserDataServices(AuctionAppContext context, UserValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    void IRepository<User>.Delete(User entity)
    {
        var userAccount = _context.Users.Find(entity.Id);
        if (userAccount == null)
            return;

        _context.Users.Remove(userAccount);
        _context.SaveChanges();
    }

    IList<User> IRepository<User>.GetAll()
    {
        return _context.Users.ToList();
    }

    User IRepository<User>.GetById(object id)
    {
        ArgumentNullException.ThrowIfNull(id);
        return _context.Users.Find(id);
    }

    User IRepository<User>.Insert(User entity)
    {
        _validator.ValidateAndThrow(entity);

        var user = _context.Users.Add(entity);
        _context.SaveChanges();
        return user.Entity;
    }

    User IRepository<User>.Update(User item)
    {
        _validator.ValidateAndThrow(item);
        var entity = _context.Users.Find(item.Id);

        ArgumentNullException.ThrowIfNull(entity);

        _context.Entry(entity).CurrentValues
            .SetValues(item);
        _context.SaveChanges();
        return item;
    }
}