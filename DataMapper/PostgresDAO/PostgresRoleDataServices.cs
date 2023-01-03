using DomainModel.Entity;

namespace DataMapper.PostgresDAO;

public class PostgresRoleDataServices : IRoleDataServices
{
    private readonly AuctionAppContext _context;

    public PostgresRoleDataServices(AuctionAppContext context)
    {
        _context = context;
    }

    public Role Insert(Role entity)
    {
        throw new NotImplementedException();
    }

    public Role Update(Role item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Role entity)
    {
        throw new NotImplementedException();
    }

    public Role GetById(object id)
    {
        throw new NotImplementedException();
    }

    public IList<Role> GetAll()
    {
        return _context.Roles.ToList();
    }
}