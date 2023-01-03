using DataMapper;
using DomainModel.DTO;

namespace ServiceLayer.ServiceImplementation;

public class CategoryServiceImpl : ICategoryService
{
    private readonly ICategoryDataServices _categoryDataServices;

    public CategoryServiceImpl(ICategoryDataServices categoryDataServices)
    {
        _categoryDataServices = categoryDataServices;
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