// <copyright file="RoleServiceImpl.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.ServiceImplementation;

using DataMapper;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ServiceLayer.Exception;

/// <summary>
/// RoleServiceImpl.
/// </summary>
/// <seealso cref="ServiceLayer.IRoleService" />
public class RoleServiceImpl : IRoleService
{
    private readonly IRoleDataServices roleDataServices;
    private readonly ILogger<RoleServiceImpl> logger;
    private readonly RoleDtoValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleServiceImpl"/> class.
    /// </summary>
    /// <param name="roleDataServices">The role data services.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="validator">The validator.</param>
    public RoleServiceImpl(IRoleDataServices roleDataServices, ILogger<RoleServiceImpl> logger, RoleDtoValidator validator)
    {
        this.roleDataServices = roleDataServices;
        this.logger = logger;
        this.validator = validator;
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of roles.</returns>
    public IList<RoleDto> GetAll()
    {
        this.logger.LogInformation("Getting all roles");

        return this.roleDataServices.GetAll().Select(role => new RoleDto(role)).ToList();
    }

    /// <summary>
    /// Deletes the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <exception cref="NotFoundException&lt;RoleDto&gt;">not found role.</exception>
    public void DeleteById(int id)
    {
        this.logger.LogInformation("Deleting role {0}", id);

        var role = this.roleDataServices.GetById(id);
        if (role == null)
        {
            throw new NotFoundException<RoleDto>(id, this.logger);
        }

        this.roleDataServices.Delete(role);
    }

    /// <summary>
    /// Updates the specified dto.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns>role.</returns>
    /// <exception cref="NotFoundException&lt;RoleDto&gt;">not found role.</exception>
    public RoleDto Update(RoleDto dto)
    {
        this.logger.LogInformation("Updating role {0}", dto);

        this.validator.ValidateAndThrow(dto);

        var role = this.roleDataServices.GetById(dto.Id);
        if (role == null)
        {
            throw new NotFoundException<RoleDto>(dto, this.logger);
        }

        role.Name = dto.Name;
        this.roleDataServices.Update(role);
        return new RoleDto(role);
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>role.</returns>
    /// <exception cref="NotFoundException&lt;RoleDto&gt;">not found role.</exception>
    public RoleDto GetById(int id)
    {
        this.logger.LogInformation("Getting role with id {0}", id);

        var role = this.roleDataServices.GetById(id);
        if (role == null)
        {
            throw new NotFoundException<RoleDto>(id, this.logger);
        }

        return new RoleDto(role);
    }

    /// <summary>
    /// Inserts the specified dto.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns>role.</returns>
    public RoleDto Insert(RoleDto dto)
    {
        this.logger.LogInformation("Inserting role {0}", dto);

        this.validator.ValidateAndThrow(dto);

        var role = new Role
        {
            Id = 0,
            Name = dto.Name,
        };

        return new RoleDto(this.roleDataServices.Insert(role));
    }
}