using DataMapper;
using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class RoleServiceImpl : IRoleService
{
    private readonly IRoleDataServices _roleDataServices;
    private readonly ILogger _logger;
    
    public RoleServiceImpl(IRoleDataServices roleDataServices, ILogger<RoleServiceImpl> logger)
    {
        _roleDataServices = roleDataServices;
        _logger = logger;
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