// <copyright file="CategoryServiceImpl.cs" company="Transilvania University of Brasov">
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
/// CategoryServiceImpl.
/// </summary>
/// <seealso cref="ServiceLayer.ICategoryService" />
public class CategoryServiceImpl : ICategoryService
{
    private readonly ICategoryDataServices categoryDataServices;

    private readonly ILogger<CategoryServiceImpl> logger;

    private readonly CategoryDtoValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryServiceImpl"/> class.
    /// </summary>
    /// <param name="categoryDataServices">The category data services.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="validator">The validator.</param>
    public CategoryServiceImpl(
    ICategoryDataServices categoryDataServices,
    ILogger<CategoryServiceImpl> logger,
    CategoryDtoValidator validator)
    {
        this.categoryDataServices = categoryDataServices;
        this.logger = logger;
        this.validator = validator;
    }

    /// <summary>
    /// Deletes the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <exception cref="NotFoundException&lt;CategoryDto&gt;"> not found. </exception>
    void ICrudService<CategoryDto>.DeleteById(int id)
    {
        this.logger.LogInformation("Delete category {0}", id);

        var category = this.categoryDataServices.GetById(id);
        if (category == null)
        {
            throw new NotFoundException<CategoryDto>(id, this.logger);
        }

        this.categoryDataServices.Delete(category);
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns> List of categories. </returns>
    IList<CategoryDto> ICrudService<CategoryDto>.GetAll()
    {
        this.logger.LogInformation("Get all categories");

        return this.categoryDataServices.GetAll().Select(c => new CategoryDto(c)).ToList();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns> category. </returns>
    /// <exception cref="NotFoundException&lt;CategoryDto&gt;"> not found. </exception>
    CategoryDto ICrudService<CategoryDto>.GetById(int id)
    {
        this.logger.LogInformation("Get category by id {0}", id);

        var category = this.categoryDataServices.GetById(id);
        if (category == null)
        {
            throw new NotFoundException<CategoryDto>(id, this.logger);
        }

        return new CategoryDto(category);
    }

    /// <summary>
    /// Inserts the specified dto.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns> category. </returns>
    CategoryDto ICrudService<CategoryDto>.Insert(CategoryDto dto)
    {
        this.logger.LogInformation("Insert category {0}", dto);

        this.validator.ValidateAndThrow(dto);

        var category = new Category
        {
            Id = 0,
            Name = dto.Name,
            ChildCategories = dto.ChildCategoryIds.Select(id => this.categoryDataServices.GetById(id)).ToList(),
            ParentCategories = dto.ParentCategoryIds.Select(id => this.categoryDataServices.GetById(id)).ToList(),
        };

        return new CategoryDto(this.categoryDataServices.Insert(category));
    }

    /// <summary>
    /// Updates the specified dto.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns> category. </returns>
    /// <exception cref="NotFoundException&lt;CategoryDto&gt;">not found.</exception>
    CategoryDto ICrudService<CategoryDto>.Update(CategoryDto dto)
    {
        this.logger.LogInformation("Update category {0}", dto);

        this.validator.ValidateAndThrow(dto);

        var category = this.categoryDataServices.GetById(dto.Id);
        if (category == null)
        {
            throw new NotFoundException<CategoryDto>(dto, this.logger);
        }

        category.Name = dto.Name;
        category.ChildCategories = dto.ChildCategoryIds.Select(id => this.categoryDataServices.GetById(id)).ToList();
        category.ParentCategories = dto.ParentCategoryIds.Select(id => this.categoryDataServices.GetById(id)).ToList();

        return new CategoryDto(this.categoryDataServices.Update(category));
    }
}