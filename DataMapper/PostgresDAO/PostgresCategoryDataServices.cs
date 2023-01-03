using DomainModel.Entity;

namespace DataMapper.PostgresDAO
{
    public class PostgresCategoryDataServices : ICategoryDataServices
    {
        private readonly AuctionAppContext _context;

        public PostgresCategoryDataServices(AuctionAppContext context)
        {
            _context = context;
        }

        void IRepository<Category>.Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        IList<Category> IRepository<Category>.GetAll()
        {
            return _context.Categories.ToList();
        }

        Category IRepository<Category>.GetById(object id)
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