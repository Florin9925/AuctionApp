using DataMapper;
using DomainModel.Dto;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class ProductServiceImpl : IProductService
{
    private readonly ICategoryDataServices _categoryDataServices;
    private readonly IProductDataServices _productDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<ProductServiceImpl> _logger;

    public ProductServiceImpl(
        IProductDataServices productDataServices,
        ILogger<ProductServiceImpl> logger,
        ICategoryDataServices categoryDataServices,
        IUserDataServices userDataServices)
    {
        _productDataServices = productDataServices;
        _logger = logger;
        _categoryDataServices = categoryDataServices;
        _userDataServices = userDataServices;
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