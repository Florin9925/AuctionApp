using DataMapper;
using DomainModel.DTO;

namespace ServiceLayer.ServiceImplementation
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductDataServices _productDataServices;

        public ProductServiceImpl(IProductDataServices productDataServices)
        {
            _productDataServices = productDataServices;
        }

        void ICRUDService<ProductDto>.Delete(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        IList<ProductDto> ICRUDService<ProductDto>.GetAll()
        {
            throw new NotImplementedException();
        }

        ProductDto ICRUDService<ProductDto>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        ProductDto ICRUDService<ProductDto>.Insert(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        ProductDto ICRUDService<ProductDto>.Update(ProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
