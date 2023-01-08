using DataMapper;
using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class CategoryServiceImpl : ICategoryService
{
    private readonly ICategoryDataServices _categoryDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<CategoryServiceImpl> _logger;

    public CategoryServiceImpl(
        ICategoryDataServices categoryDataServices,
        IUserDataServices userDataServices,
        ILogger<CategoryServiceImpl> logger)
    {
        _categoryDataServices = categoryDataServices;
        _userDataServices = userDataServices;
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