using DomainModel.Entity;

namespace DataMapper.PostgresDAO
{
    public class PostgresCategoryDataServices : ICategoryDataServices
    {
        private readonly AuctionAppContext context;

        public PostgresCategoryDataServices(AuctionAppContext context)
        {
            this.context = context;
        }

        void IRepository<Category>.Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        IList<Category> IRepository<Category>.GetAll()
        {
            throw new NotImplementedException();
        }

        Category IRepository<Category>.GetByID(object id)
        {
            throw new NotImplementedException();
        }

        Category IRepository<Category>.Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        Category IRepository<Category>.Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
