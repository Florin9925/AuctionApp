using DataMapper;
using DomainModel;

namespace ServiceLayer.ServiceImplementation
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryDataServices categoryDataServices;

        public CategoryServiceImpl(ICategoryDataServices categoryDataServices)
        {
            this.categoryDataServices = categoryDataServices;
        }

        void ICRUDService<ICategoryService>.Delete(ICategoryService entity)
        {
            throw new NotImplementedException();
        }

        IList<ICategoryService> ICRUDService<ICategoryService>.GetAll()
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ICategoryService>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ICategoryService>.Insert(ICategoryService entity)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ICategoryService>.Update(ICategoryService entity)
        {
            throw new NotImplementedException();
        }
    }
}
