using DataMapper;
using DomainModel.DTO;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class CategoryServiceImpl : ICategoryService
{
    private readonly ICategoryDataServices _categoryDataServices;
    private readonly ILogger _logger;

    public CategoryServiceImpl(ICategoryDataServices categoryDataServices, ILogger<CategoryServiceImpl> logger)
    {
        _categoryDataServices = categoryDataServices;
        _logger = logger;
    }

    void ICRUDService<CategoryDto>.Delete(CategoryDto dto)
    {
        throw new NotImplementedException();
    }

    IList<CategoryDto> ICRUDService<CategoryDto>.GetAll()
    {
        throw new NotImplementedException();
    }

    CategoryDto ICRUDService<CategoryDto>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    CategoryDto ICRUDService<CategoryDto>.Insert(CategoryDto dto)
    {
        throw new NotImplementedException();
    }

    CategoryDto ICRUDService<CategoryDto>.Update(CategoryDto dto)
    {
        throw new NotImplementedException();
    }
}