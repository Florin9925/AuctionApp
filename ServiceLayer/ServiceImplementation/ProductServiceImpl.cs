using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ServiceLayer.Exception;

namespace ServiceLayer.ServiceImplementation;

public class ProductServiceImpl : IProductService
{
    private readonly ICategoryDataServices _categoryDataServices;
    private readonly IProductDataServices _productDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<ProductServiceImpl> _logger;
    private readonly ProductDtoValidator _validator;

    public ProductServiceImpl(
        IProductDataServices productDataServices,
        ILogger<ProductServiceImpl> logger,
        ICategoryDataServices categoryDataServices,
        IUserDataServices userDataServices,
        ProductDtoValidator validator)
    {
        _productDataServices = productDataServices;
        _logger = logger;
        _categoryDataServices = categoryDataServices;
        _userDataServices = userDataServices;
        _validator = validator;
    }

    void ICRUDService<ProductDto>.Delete(ProductDto dto)
    {
        _logger.LogInformation("Delete product");
        var product = _productDataServices.GetById(dto.Id);

        if (product == null)
        {
            throw new NotFoundException<ProductDto>(dto, _logger);
        }

        _productDataServices.Delete(product);
    }

    IList<ProductDto> ICRUDService<ProductDto>.GetAll()
    {
        _logger.LogInformation("Get all products");

        return _productDataServices.GetAll().Select(p => new ProductDto(p)).ToList();
    }

    ProductDto ICRUDService<ProductDto>.GetById(int id)
    {
        _logger.LogInformation("Get product by id");

        var product = _productDataServices.GetById(id);

        if (product == null)
        {
            throw new NotFoundException<ProductDto>(id, _logger);
        }

        return new ProductDto(product);
    }

    ProductDto ICRUDService<ProductDto>.Insert(ProductDto dto)
    {
        _logger.LogInformation("Insert product");

        _validator.ValidateAndThrow(dto);

        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Offers = new List<Offer>(),
            Amount = dto.Amount,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Currency = dto.Currency,
            Category = _categoryDataServices.GetById(dto.CategoryId),
            Owner = _userDataServices.GetById(dto.OwnerId)
        };
        
        return new ProductDto(_productDataServices.Insert(product));
    }

    ProductDto ICRUDService<ProductDto>.Update(ProductDto dto)
    {
        throw new NotImplementedException();
    }
}