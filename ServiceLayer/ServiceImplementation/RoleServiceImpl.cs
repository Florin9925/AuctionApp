using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ServiceLayer.Exception;

namespace ServiceLayer.ServiceImplementation;

public class RoleServiceImpl : IRoleService
{
    private readonly IRoleDataServices _roleDataServices;
    private readonly ILogger<RoleServiceImpl> _logger;
    private readonly RoleDtoValidator _validator;

    public RoleServiceImpl(IRoleDataServices roleDataServices, ILogger<RoleServiceImpl> logger,
        RoleDtoValidator validator)
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
        _logger.LogInformation("Deleting role with id {0}", dto.Id);

        var role = _roleDataServices.GetById(dto.Id);
        if (role == null)
        {
            throw new NotFoundException<RoleDto>(dto, _logger);
        }

        _roleDataServices.Delete(role);
    }

    public RoleDto Update(RoleDto dto)
    {
        _logger.LogInformation("Updating role with id {0}", dto.Id);

        _validator.ValidateAndThrow(dto);

        var role = _roleDataServices.GetById(dto.Id);
        if (role == null)
        { 
            throw new NotFoundException<RoleDto>(dto, _logger);
        }

        role.Name = dto.Name;
        _roleDataServices.Update(role);
        return new RoleDto(role);
    }

    public RoleDto GetById(int id)
    {
        _logger.LogInformation("Getting role with id {0}", id);

        var role = _roleDataServices.GetById(id);
        if (role == null)
        {
            throw new NotFoundException<RoleDto>(id, _logger);
        }

        return new RoleDto(role);
    }

    public RoleDto Insert(RoleDto dto)
    {
        _logger.LogInformation("Inserting role with name {0}", dto.Name);

        _validator.ValidateAndThrow(dto);

        var role = new Role
        {
            Id = 0,
            Name = dto.Name
        };

        return new RoleDto(_roleDataServices.Insert(role));
    }
}