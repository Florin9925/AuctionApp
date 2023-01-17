// <copyright file="ProductServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestServiceLayer;

using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

/// <summary>
/// ProductServiceTest.
/// </summary>
[TestClass]
public class ProductServiceTest
{
    private Product product;

    private Product nullProduct = null;

    private ProductDto notFoundProduct;

    private ProductDto productDto;

    private IProductService productService;

    private Mock<IProductDataServices> productDataServicesMock;

    private Mock<ICategoryDataServices> categoryDataServicesMock;

    private Mock<IUserDataServices> userDataServicesMock;

    private Mock<ILogger<ProductServiceImpl>> loggerMock;

    private MyConfiguration myConfiguration;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        this.product = new Product
        {
            Id = 1,
            Name = "Product 1",
            Description = "Description 1",
            InitialPrice = 100,
            Category = new Category { Id = 1, Name = "Category 1" },
            Owner = new User { Id = 1 },
            Amount = 1,
            StartDate = DateTime.Now.AddDays(1),
            EndDate = DateTime.Now.AddDays(2),
        };

        this.notFoundProduct = new ProductDto
        {
            Id = int.MaxValue,
            Name = "Product 2",
            Description = "Description 2",
            InitialPrice = 200,
            CategoryId = int.MaxValue,
            OwnerId = int.MaxValue,
            Amount = 1,
            StartDate = DateTime.Now.AddDays(1),
            EndDate = DateTime.Now.AddDays(2),
        };

        this.productDto = new ProductDto(this.product);

        this.categoryDataServicesMock = new Mock<ICategoryDataServices>();
        this.userDataServicesMock = new Mock<IUserDataServices>();
        this.loggerMock = new Mock<ILogger<ProductServiceImpl>>();
        this.productDataServicesMock = new Mock<IProductDataServices>();
        this.myConfiguration = new MyConfiguration
        {
            K = 5,
            P = 5,
            S = 5,
            Z = 5,
        };

        this.productService = new ProductServiceImpl(
            this.productDataServicesMock.Object,
            this.loggerMock.Object,
            this.categoryDataServicesMock.Object,
            this.userDataServicesMock.Object,
            new ProductDtoValidator(),
            Options.Create(this.myConfiguration));
    }

    /// <summary>
    /// Tests the product get all.
    /// </summary>
    [TestMethod]
    public void TestProductGetAll()
    {
        this.productDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Product> { this.product });

        var result = this.productService.GetAll();

        CollectionAssert.AreEqual(new List<ProductDto> { this.productDto }, result.ToList());
    }

    /// <summary>
    /// Tests the product get by identifier.
    /// </summary>
    [TestMethod]
    public void TestProductGetById()
    {
        this.productDataServicesMock.Setup(x => x.GetById(this.product.Id)).Returns(this.product);

        var result = this.productService.GetById(this.product.Id);

        Assert.AreEqual(this.productDto, result);
    }

    /// <summary>
    /// Tests the product get by identifier not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestProductGetByIdNotFound()
    {
        this.productDataServicesMock.Setup(x => x.GetById(this.notFoundProduct.Id)).Returns(this.nullProduct);

        this.productService.GetById(this.notFoundProduct.Id);
    }

    /// <summary>
    /// Tests the product delete by identifier.
    /// </summary>
    [TestMethod]
    public void TestProductDeleteById()
    {
        this.productDataServicesMock.Setup(x => x.GetById(this.product.Id)).Returns(this.product);

        this.productService.DeleteById(this.product.Id);

        this.productDataServicesMock.Verify(x => x.Delete(this.product), Times.Once);
    }

    /// <summary>
    /// Tests the product delete by identifier not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestProductDeleteByIdNotFound()
    {
        this.productDataServicesMock.Setup(x => x.GetById(this.notFoundProduct.Id)).Returns(this.nullProduct);

        this.productService.DeleteById(this.notFoundProduct.Id);
    }

    /// <summary>
    /// Tests the product insert.
    /// </summary>
    [TestMethod]
    public void TestProductInsert()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.productDto.CategoryId)).Returns(this.product.Category);
        this.userDataServicesMock.Setup(x => x.GetById(this.productDto.OwnerId)).Returns(this.product.Owner);
        this.productDataServicesMock.Setup(x => x.Insert(It.IsAny<Product>())).Returns(this.product);

        var result = this.productService.Insert(this.productDto);

        Assert.AreEqual(this.productDto, result);
    }

    /// <summary>
    /// Tests the product insert category not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<Category>))]
    public void TestProductInsertCategoryNotFound()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.productDto.CategoryId)).Returns((Category)null);
        this.userDataServicesMock.Setup(x => x.GetById(this.productDto.OwnerId)).Returns(this.product.Owner);
        this.productDataServicesMock.Setup(x => x.Insert(It.IsAny<Product>())).Returns(this.product);

        var result = this.productService.Insert(this.productDto);

        Assert.AreEqual(this.productDto, result);
    }

    /// <summary>
    /// Tests the product insert user not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<User>))]
    public void TestProductInsertUserNotFound()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.productDto.CategoryId)).Returns(this.product.Category);
        this.userDataServicesMock.Setup(x => x.GetById(this.productDto.OwnerId)).Returns((User)null);
        this.productDataServicesMock.Setup(x => x.Insert(It.IsAny<Product>())).Returns(this.product);

        var result = this.productService.Insert(this.productDto);

        Assert.AreEqual(this.productDto, result);
    }

    /// <summary>
    /// Tests the product insert validation exception.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FluentValidation.ValidationException))]
    public void TestProductInsertValidationException()
    {
        this.productService.Insert(new ProductDto());
    }

    /// <summary>
    /// Tests the product insert description similar exception.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ProductDescriptionSimilarException))]
    public void TestProductInsertDescriptionSimilarException()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.productDto.CategoryId)).Returns(this.product.Category);
        this.userDataServicesMock.Setup(x => x.GetById(this.productDto.OwnerId)).Returns(this.product.Owner);
        this.productDataServicesMock.Setup(x => x.GetUserProductDescriptions(It.IsAny<int>()))
            .Returns(new List<string> { this.product.Description });

        this.productService.Insert(this.productDto);
    }

    /// <summary>
    /// Tests the product insert too many products exception.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(TooManyProductsException))]
    public void TestProductInsertTooManyProductsException()
    {
        this.productDataServicesMock.Setup(x => x.GetActiveUserProductsCount(It.IsAny<int>())).Returns(int.MaxValue);

        this.productService.Insert(this.productDto);
    }

    /// <summary>
    /// Tests the product update.
    /// </summary>
    [TestMethod]
    public void TestProductUpdate()
    {
        this.productDataServicesMock.Setup(x => x.GetById(this.product.Id)).Returns(this.product);
        this.categoryDataServicesMock.Setup(x => x.GetById(this.productDto.CategoryId)).Returns(this.product.Category);
        this.userDataServicesMock.Setup(x => x.GetById(this.productDto.OwnerId)).Returns(this.product.Owner);
        this.productDataServicesMock.Setup(x => x.Update(It.IsAny<Product>())).Returns(this.product);

        var result = this.productService.Update(this.productDto);

        Assert.AreEqual(this.productDto, result);
    }

    /// <summary>
    /// Tests the product update not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestProductUpdateNotFound()
    {
        this.productDataServicesMock.Setup(x => x.GetById(this.product.Id)).Returns(this.nullProduct);
        this.productService.Update(this.productDto);
    }
}