// <copyright file="ProductServiceImpl.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.ServiceImplementation;

using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer.Exception;
using ServiceLayer.Utils;

/// <summary>
/// ProductServiceImpl.
/// </summary>
/// <seealso cref="ServiceLayer.IProductService" />
public class ProductServiceImpl : IProductService
{
    private readonly ICategoryDataServices categoryDataServices;
    private readonly IProductDataServices productDataServices;
    private readonly IUserDataServices userDataServices;
    private readonly ILogger<ProductServiceImpl> logger;
    private readonly ProductDtoValidator validator;
    private readonly MyConfiguration myConfiguration;


    /// <summary>
    /// Initializes a new instance of the <see cref="ProductServiceImpl"/> class.
    /// </summary>
    /// <param name="productDataServices">The product data services.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="categoryDataServices">The category data services.</param>
    /// <param name="userDataServices">The user data services.</param>
    /// <param name="validator">The validator.</param>
    /// <param name="myConfiguration">My configuration.</param>
    public ProductServiceImpl(
        IProductDataServices productDataServices,
        ILogger<ProductServiceImpl> logger,
        ICategoryDataServices categoryDataServices,
        IUserDataServices userDataServices,
        ProductDtoValidator validator,
        IOptions<MyConfiguration> myConfiguration)
    {
        this.productDataServices = productDataServices;
        this.logger = logger;
        this.categoryDataServices = categoryDataServices;
        this.userDataServices = userDataServices;
        this.validator = validator;
        this.myConfiguration = myConfiguration.Value;
    }

    /// <summary>
    /// Deletes the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <exception cref="NotFoundException&lt;ProductDto&gt;">not found product.</exception>
    void ICrudService<ProductDto>.DeleteById(int id)
    {
        this.logger.LogInformation("Delete product");
        var product = this.productDataServices.GetById(id);

        if (product == null)
        {
            throw new NotFoundException<ProductDto>(id, this.logger);
        }

        this.productDataServices.Delete(product);
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>list of products.</returns>
    IList<ProductDto> ICrudService<ProductDto>.GetAll()
    {
        this.logger.LogInformation("Get all products");

        return this.productDataServices.GetAll().Select(p => new ProductDto(p)).ToList();
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>product.</returns>
    /// <exception cref="NotFoundException&lt;ProductDto&gt;">not found product.</exception>
    ProductDto ICrudService<ProductDto>.GetById(int id)
    {
        this.logger.LogInformation("Get product by id");

        var product = this.productDataServices.GetById(id);

        if (product == null)
        {
            throw new NotFoundException<ProductDto>(id, this.logger);
        }

        return new ProductDto(product);
    }

    /// <summary>
    /// Inserts the specified dto.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns>product.</returns>
    /// <exception cref="ServiceLayer.Exception.TooManyProductsException">to many products.</exception>
    /// <exception cref="NotFoundException&lt;Category&gt;">not found category.</exception>
    /// <exception cref="NotFoundException&lt;User&gt;">not found user.</exception>
    ProductDto ICrudService<ProductDto>.Insert(ProductDto dto)
    {
        this.logger.LogInformation("Insert product");

        this.validator.ValidateAndThrow(dto);

        this.CheckProductDescription(dto);

        if (this.productDataServices.GetActiveUserProductsCount(dto.OwnerId) > this.myConfiguration.K)
        {
            throw new TooManyProductsException(this.logger);
        }

        var category = this.categoryDataServices.GetById(dto.CategoryId);
        if (category == null)
        {
            throw new NotFoundException<Category>(dto.CategoryId, this.logger);
        }

        var user = this.userDataServices.GetById(dto.OwnerId);
        if (user == null)
        {
            throw new NotFoundException<User>(dto.OwnerId, this.logger);
        }

        var product = new Product
        {
            Id = 0,
            Name = dto.Name,
            Description = dto.Description,
            Offers = new List<Offer>(),
            Amount = dto.Amount,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Currency = dto.Currency,
            Category = category,
            Owner = user,
        };

        return new ProductDto(this.productDataServices.Insert(product));
    }

    /// <summary>
    /// Updates the specified dto.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <returns>product.</returns>
    /// <exception cref="NotFoundException&lt;ProductDto&gt;">not found category.</exception>
    ProductDto ICrudService<ProductDto>.Update(ProductDto dto)
    {
        this.logger.LogInformation("Update product");

        this.validator.ValidateAndThrow(dto);

        var product = this.productDataServices.GetById(dto.Id);

        if (product == null)
        {
            throw new NotFoundException<ProductDto>(dto, this.logger);
        }

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Amount = dto.Amount;
        product.StartDate = dto.StartDate;
        product.EndDate = dto.EndDate;
        product.Currency = dto.Currency;
        product.IsCompleted = dto.IsCompleted;
        product.InitialPrice = dto.InitialPrice;
        product.Category = this.categoryDataServices.GetById(dto.CategoryId);

        return new ProductDto(this.productDataServices.Update(product));
    }

    /// <summary>
    /// Checks the product description.
    /// </summary>
    /// <param name="dto">The dto.</param>
    /// <exception cref="ServiceLayer.Exception.ProductDescriptionSimilarException">similar description.</exception>
    private void CheckProductDescription(ProductDto dto)
    {
        var descriptions = this.productDataServices.GetUserProductDescriptions(dto.OwnerId);

        if (descriptions.Any(description => StringDistance.LevenshteinDistance(dto.Description, description) < 20))
        {
            throw new ProductDescriptionSimilarException(this.logger);
        }
    }
}