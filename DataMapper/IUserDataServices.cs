// <copyright file="IUserDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper;

using DomainModel.Entity;

/// <summary>
/// IUserDataServices.
/// </summary>
/// <seealso cref="DataMapper.IRepository&lt;DomainModel.Entity.User&gt;" />
public interface IUserDataServices : IRepository<User>
{
}