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
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductDataServices productDataServices;

        public ProductServiceImpl(IProductDataServices productDataServices)
        {
            this.productDataServices = productDataServices;
        }

        void ICRUDService<ProductDto>.Delete(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        IList<ProductDto> ICRUDService<ProductDto>.GetAll()
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ProductDto>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ProductDto>.Insert(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<ProductDto>.Update(ProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
