// <copyright file="ICategoryDataServices.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper;

using DomainModel.Entity;

/// <summary>
/// ICategoryDataServices.
/// </summary>
/// <seealso cref="DataMapper.IRepository&lt;DomainModel.Entity.Category&gt;" />
public interface ICategoryDataServices : IRepository<Category>
{
}