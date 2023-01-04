using DomainModel.Entity;
using FluentValidation;

namespace DataMapper.PostgresDAO;

public class PostgresRoleDataServices : IRoleDataServices
{
    private readonly AuctionAppContext _context;
    private readonly RoleValidator _validator;

    public PostgresRoleDataServices(AuctionAppContext context, RoleValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    public Role Insert(Role entity)
    {
        _validator.ValidateAndThrow(entity);
        var role = _context.Add(entity);
        _context.SaveChanges();
        return role.Entity;
    }

    public Role Update(Role item)
    {
        _validator.ValidateAndThrow(item);

        var role = _context.Roles.Find(item.Id);

        ArgumentNullException.ThrowIfNull(role);

        _context.Entry(role).CurrentValues.SetValues(item);
        _context.SaveChanges();
        return item;
    }

    public void Delete(Role entity)
    {
        var role = _context.Roles.Find(entity.Id);
        if (role == null)
            return;

        _context.Remove(role);
        _context.SaveChanges();
    }

    public Role GetById(object id)
    {
        return _context.Roles.Find(id);
    }

    public IList<Role> GetAll()
    {
        return _context.Roles.ToList();
    }
}