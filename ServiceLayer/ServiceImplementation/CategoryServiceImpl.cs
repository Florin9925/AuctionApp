using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ServiceLayer.Exception;

namespace ServiceLayer.ServiceImplementation;

public class CategoryServiceImpl : ICategoryService
{
    private readonly ICategoryDataServices _categoryDataServices;
    private readonly ILogger<CategoryServiceImpl> _logger;
    private readonly CategoryDtoValidator _validator;

    public CategoryServiceImpl(
        ICategoryDataServices categoryDataServices,
        ILogger<CategoryServiceImpl> logger,
        CategoryDtoValidator validator)
    {
        _categoryDataServices = categoryDataServices;
        _logger = logger;
        _validator = validator;
    }

    void ICRUDService<CategoryDto>.Delete(CategoryDto dto)
    {
        _logger.LogInformation("Delete category {0}", dto);

        var category = _categoryDataServices.GetById(dto.Id);
        if (category == null)
        {
            throw new NotFoundException<CategoryDto>(dto, _logger);
        }

        _categoryDataServices.Delete(category);
    }

    IList<CategoryDto> ICRUDService<CategoryDto>.GetAll()
    {
        _logger.LogInformation("Get all categories");

        return _categoryDataServices.GetAll().Select(c => new CategoryDto(c)).ToList();
    }

    CategoryDto ICRUDService<CategoryDto>.GetById(int id)
    {
        _logger.LogInformation("Get category by id {0}", id);

        var category = _categoryDataServices.GetById(id);
        if (category == null)
        {
            throw new NotFoundException<CategoryDto>(id, _logger);
        }

        return new CategoryDto(category);
    }

    CategoryDto ICRUDService<CategoryDto>.Insert(CategoryDto dto)
    {
        _logger.LogInformation("Insert category {0}", dto);

        _validator.ValidateAndThrow(dto);

        var category = new Category
        {
            Id = dto.Id,
            Name = dto.Name,
            ChildCategories = dto.ChildCategoryIds.Select(id => _categoryDataServices.GetById(id)).ToList(),
            ParentCategories = dto.ParentCategoryIds.Select(id => _categoryDataServices.GetById(id)).ToList()
        };

        _categoryDataServices.Insert(category);

        return new CategoryDto(category);
    }

    CategoryDto ICRUDService<CategoryDto>.Update(CategoryDto dto)
    {
        _logger.LogInformation("Update category {0}", dto);

        _validator.ValidateAndThrow(dto);

        var category = _categoryDataServices.GetById(dto.Id);
        if (category == null)
        {
            throw new NotFoundException<CategoryDto>(dto, _logger);
        }

        category.Name = dto.Name;
        category.ChildCategories = dto.ChildCategoryIds.Select(id => _categoryDataServices.GetById(id)).ToList();
        category.ParentCategories = dto.ParentCategoryIds.Select(id => _categoryDataServices.GetById(id)).ToList();

        return new CategoryDto(_categoryDataServices.Update(category));
    }
}