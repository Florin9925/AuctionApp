using DataMapper;
using DomainModel.DTO;
using DomainModel.Entity;

namespace ServiceLayer.ServiceImplementation;

public class RoleServiceImpl : IRoleService
{
    private readonly IRoleDataServices _roleDataServices;

    public RoleServiceImpl(IRoleDataServices roleDataServices)
    {
        _roleDataServices = roleDataServices;
    }

    public IList<RoleDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Delete(RoleDto dto)
    {
        throw new NotImplementedException();
    }

    public RoleDto Update(RoleDto dto)
    {
        throw new NotImplementedException();
    }

    public RoleDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public RoleDto Insert(RoleDto dto)
    {
        throw new NotImplementedException();
    }
}