using DataMapper;
using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceImplementation
{
    public class AuctionServiceImpl : IAuctionService
    {
        private readonly IAuctionDataServices auctionDataServices;

        public AuctionServiceImpl(IAuctionDataServices auctionDataServices)
        {
            this.auctionDataServices = auctionDataServices;
        }

        void ICRUDService<Product.Auction>.Delete(Product.Auction entity)
        {
            throw new NotImplementedException();
        }

        IList<Product.Auction> ICRUDService<Product.Auction>.GetAll()
        {
            throw new NotImplementedException();
        }

        void ICRUDService<Product.Auction>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<Product.Auction>.Insert(Product.Auction entity)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<Product.Auction>.Update(Product.Auction entity)
        {
            throw new NotImplementedException();
        }
    }
}
