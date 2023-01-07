using DataMapper;
using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class RoleServiceImpl : IRoleService
{
    private readonly IRoleDataServices _roleDataServices;
    private readonly ILogger _logger;
    private readonly RoleDtoValidator _validator;

    public RoleServiceImpl(IRoleDataServices roleDataServices, ILogger logger, RoleDtoValidator validator)
    {
        _roleDataServices = roleDataServices;
        _logger = logger;
        _validator = validator;
    }

    public IList<RoleDto> GetAll()
    {
        _logger.LogInformation("Getting all roles");
        return _roleDataServices.GetAll().Select(role => new RoleDto(role)).ToList();
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