using DomainModel;

namespace DataMapper.PostgresDAO
{
    public class PostgresProductDataServices : IProductDataServices
    {
        private readonly AuctionAppContext context;

        public PostgresProductDataServices(AuctionAppContext context)
        {
            this.context = context;
        }

        void IRepository<Product>.Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        IList<Product> IRepository<Product>.GetAll()
        {
            throw new NotImplementedException();
        }

        Product IRepository<Product>.GetByID(object id)
        {
            throw new NotImplementedException();
        }

        Product IRepository<Product>.Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        Product IRepository<Product>.Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
