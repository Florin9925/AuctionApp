using DomainModel;

namespace DataMapper.PostgresDAO
{
    internal class PostgresAuctionDataServices : IAuctionDataServices
    {
        private readonly AuctionAppContext _context;

        public PostgresAuctionDataServices(AuctionAppContext context)
        {
            _context = context;
        }

        void IRepository<Product.Auction>.Delete(Product.Auction entity)
        {
            throw new NotImplementedException();
        }

        IList<Product.Auction> IRepository<Product.Auction>.GetAll()
        {
            throw new NotImplementedException();
        }

        Product.Auction IRepository<Product.Auction>.GetByID(object id)
        {
            throw new NotImplementedException();
        }

        Product.Auction IRepository<Product.Auction>.Insert(Product.Auction entity)
        {
            throw new NotImplementedException();
        }

        Product.Auction IRepository<Product.Auction>.Update(Product.Auction item)
        {
            throw new NotImplementedException();
        }
    }
}
