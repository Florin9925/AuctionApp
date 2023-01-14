using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer.Exception;
using ServiceLayer.Utils;

namespace ServiceLayer.ServiceImplementation;

public class ProductServiceImpl : IProductService
{
    private readonly ICategoryDataServices _categoryDataServices;
    private readonly IProductDataServices _productDataServices;
    private readonly IUserDataServices _userDataServices;
    private readonly ILogger<ProductServiceImpl> _logger;
    private readonly ProductDtoValidator _validator;
    private readonly MyConfiguration _myConfiguration;


    public ProductServiceImpl(
        IProductDataServices productDataServices,
        ILogger<ProductServiceImpl> logger,
        ICategoryDataServices categoryDataServices,
        IUserDataServices userDataServices,
        ProductDtoValidator validator,
        IOptions<MyConfiguration> myConfiguration)
    {
        _productDataServices = productDataServices;
        _logger = logger;
        _categoryDataServices = categoryDataServices;
        _userDataServices = userDataServices;
        _validator = validator;
        _myConfiguration = myConfiguration.Value;
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

        CheckProductDescription(dto);

        if (_productDataServices.GetActiveUserProductsCount(dto.OwnerId) > _myConfiguration.K)
        {
            throw new ToManyProductsException(_logger);
        }

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

    private void CheckProductDescription(ProductDto dto)
    {
        var descriptions = _productDataServices.GetUserProductDescriptions(dto.OwnerId);

        if (descriptions.Any(description => StringDistance.LevenshteinDistance(dto.Description, description) < 20))
        {
            throw new ProductDescriptionSimilarException(_logger);
        }
    }

    ProductDto ICRUDService<ProductDto>.Update(ProductDto dto)
    {
        _logger.LogInformation("Update product");

        _validator.ValidateAndThrow(dto);

        var product = _productDataServices.GetById(dto.Id);

        if (product == null)
        {
            throw new NotFoundException<ProductDto>(dto, _logger);
        }

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Amount = dto.Amount;
        product.StartDate = dto.StartDate;
        product.EndDate = dto.EndDate;
        product.Currency = dto.Currency;
        product.IsCompleted = dto.IsCompleted;
        product.InitialPrice = dto.InitialPrice;
        product.Category = _categoryDataServices.GetById(dto.CategoryId);

        return new ProductDto(_productDataServices.Update(product));
    }
}