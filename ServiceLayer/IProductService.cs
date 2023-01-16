// <copyright file="IProductService.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer;

using DomainModel.Dto;

/// <summary>
/// IProductService.
/// </summary>
/// <seealso cref="ICrudService{T}.Dto.ProductDto&gt;" />
public interface IProductService : ICrudService<ProductDto>
{
}