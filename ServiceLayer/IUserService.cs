// <copyright file="IUserService.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer;

using DomainModel.Dto;

/// <summary>
/// IUserService.
/// </summary>
/// <seealso cref="ICrudService{T}.Dto.UserDto&gt;" />
public interface IUserService : ICrudService<UserDto>
{
}