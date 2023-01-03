using DomainModel.Entity;
using FluentValidation;

namespace DataMapper.PostgresDAO;

public class PostgresUserDataServices : IUserDataServices
{
    private readonly AuctionAppContext _context;
    private readonly UserValidator _validations;

    public PostgresUserDataServices(AuctionAppContext context, UserValidator validations)
    {
        _context = context;
        _validations = validations;
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
        if (id == null)
        {
            throw new ArgumentNullException("id");
        }

        return _context.Users.Find(id);
    }

    User IRepository<User>.Insert(User entity)
    {
        _validations.ValidateAndThrow(entity);

        var user = _context.Users.Add(entity);
        _context.SaveChanges();
        return user.Entity;

    }

    User IRepository<User>.Update(User item)
    {
        _validations.ValidateAndThrow(item);
        var entity = _context.Users.Find(item.Id);
            
        _context.Users.Entry(entity).CurrentValues
            .SetValues(item);
        _context.SaveChanges();
        return item;

    }
}