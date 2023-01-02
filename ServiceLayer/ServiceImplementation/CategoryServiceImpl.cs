using DataMapper;
using DomainModel;
using DomainModel.DTO;

namespace ServiceLayer.ServiceImplementation
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryDataServices categoryDataServices;

        public CategoryServiceImpl(ICategoryDataServices categoryDataServices)
        {
            this.categoryDataServices = categoryDataServices;
        }

        void ICRUDService<CategoryDto>.Delete(CategoryDto dto)
        {
            throw new NotImplementedException();
        }

        IList<CategoryDto> ICRUDService<CategoryDto>.GetAll()
        {
            throw new NotImplementedException();
        }

        void ICRUDService<CategoryDto>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<CategoryDto>.Insert(CategoryDto dto)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<CategoryDto>.Update(CategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
