using DataMapper;
using DomainModel;
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

        void ICRUDService<Product>.Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        IList<Product> ICRUDService<Product>.GetAll()
        {
            throw new NotImplementedException();
        }

        void ICRUDService<Product>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<Product>.Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        void ICRUDService<Product>.Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
