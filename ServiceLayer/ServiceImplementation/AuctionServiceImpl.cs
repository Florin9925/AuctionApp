using DataMapper;
using DomainModel.DTO;
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

        void ICRUDService<ProductDto.AuctionDto>.Delete(ProductDto.AuctionDto dto)
        {
            throw new NotImplementedException();
        }

        IList<ProductDto.AuctionDto> ICRUDService<ProductDto.AuctionDto>.GetAll()
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ProductDto.AuctionDto>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ProductDto.AuctionDto>.Insert(ProductDto.AuctionDto dto)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ProductDto.AuctionDto>.Update(ProductDto.AuctionDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
