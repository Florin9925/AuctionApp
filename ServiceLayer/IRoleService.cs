// <copyright file="IRoleService.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer;

using DomainModel.Dto;

/// <summary>
/// IRoleService.
/// </summary>
/// <seealso cref="ICrudService{T}.Dto.RoleDto&gt;" />
public interface IRoleService : ICrudService<RoleDto>
{
}