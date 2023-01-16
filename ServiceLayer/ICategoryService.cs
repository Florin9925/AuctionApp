// <copyright file="ICategoryService.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer;

using DomainModel.Dto;

/// <summary>
/// ICategoryService.
/// </summary>
/// <seealso cref="ICrudService{T}.Dto.CategoryDto&gt;" />
public interface ICategoryService : ICrudService<CategoryDto>
{
}