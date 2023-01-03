using DataMapper;
using DomainModel.DTO;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class ProductServiceImpl : IProductService
{
    private readonly IProductDataServices _productDataServices;
    private readonly ILogger _logger;

    public ProductServiceImpl(IProductDataServices productDataServices, ILogger<ProductServiceImpl> logger)
    {
        _productDataServices = productDataServices;
        _logger = logger;
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