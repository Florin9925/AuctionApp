// <copyright file="IRoleDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper;

using DomainModel.Entity;

/// <summary>
/// IRoleDataServices.
/// </summary>
/// <seealso cref="DataMapper.IRepository&lt;DomainModel.Entity.Role&gt;" />
public interface IRoleDataServices : IRepository<Role>
{
}