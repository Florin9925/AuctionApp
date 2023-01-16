using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

namespace TestServiceLayer;

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

    [TestInitialize]
    public void Setup()
    {
        product = new Product
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

        notFoundProduct = new ProductDto
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

        productDto = new ProductDto(product);

        categoryDataServicesMock = new Mock<ICategoryDataServices>();
        userDataServicesMock = new Mock<IUserDataServices>();
        loggerMock = new Mock<ILogger<ProductServiceImpl>>();
        productDataServicesMock = new Mock<IProductDataServices>();
        myConfiguration = new MyConfiguration
        {
            K = 5, P = 5, S = 5, Z = 5
        };

        productService = new ProductServiceImpl(
            productDataServicesMock.Object,
            loggerMock.Object,
            categoryDataServicesMock.Object,
            userDataServicesMock.Object,
            new ProductDtoValidator(),
            Options.Create(myConfiguration));
    }

    [TestMethod]
    public void TestProductGetAll()
    {
        productDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Product> { product });

        var result = productService.GetAll();

        CollectionAssert.AreEqual(new List<ProductDto> { productDto }, result.ToList());
    }

    [TestMethod]
    public void TestProductGetById()
    {
        productDataServicesMock.Setup(x => x.GetById(product.Id)).Returns(product);

        var result = productService.GetById(product.Id);

        Assert.AreEqual(productDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestProductGetByIdNotFound()
    {
        productDataServicesMock.Setup(x => x.GetById(notFoundProduct.Id)).Returns(nullProduct);

        productService.GetById(notFoundProduct.Id);
    }

    [TestMethod]
    public void TestProductDeleteById()
    {
        productDataServicesMock.Setup(x => x.GetById(product.Id)).Returns(product);

        productService.DeleteById(product.Id);

        productDataServicesMock.Verify(x => x.Delete(product), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestProductDeleteByIdNotFound()
    {
        productDataServicesMock.Setup(x => x.GetById(notFoundProduct.Id)).Returns(nullProduct);

        productService.DeleteById(notFoundProduct.Id);
    }

    [TestMethod]
    public void TestProductInsert()
    {
        categoryDataServicesMock.Setup(x => x.GetById(productDto.CategoryId)).Returns(product.Category);
        userDataServicesMock.Setup(x => x.GetById(productDto.OwnerId)).Returns(product.Owner);
        productDataServicesMock.Setup(x => x.Insert(It.IsAny<Product>())).Returns(product);

        var result = productService.Insert(productDto);

        Assert.AreEqual(productDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<Category>))]
    public void TestProductInsertCategoryNotFound()
    {
        categoryDataServicesMock.Setup(x => x.GetById(productDto.CategoryId)).Returns((Category)null);
        userDataServicesMock.Setup(x => x.GetById(productDto.OwnerId)).Returns(product.Owner);
        productDataServicesMock.Setup(x => x.Insert(It.IsAny<Product>())).Returns(product);

        var result = productService.Insert(productDto);

        Assert.AreEqual(productDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<User>))]
    public void TestProductInsertUserNotFound()
    {
        categoryDataServicesMock.Setup(x => x.GetById(productDto.CategoryId)).Returns(product.Category);
        userDataServicesMock.Setup(x => x.GetById(productDto.OwnerId)).Returns((User)null);
        productDataServicesMock.Setup(x => x.Insert(It.IsAny<Product>())).Returns(product);

        var result = productService.Insert(productDto);

        Assert.AreEqual(productDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(FluentValidation.ValidationException))]
    public void TestProductInsertValidationException()
    {
        productService.Insert(new ProductDto());
    }

    [TestMethod]
    [ExpectedException(typeof(ProductDescriptionSimilarException))]
    public void TestProductInsertDescriptionSimilarException()
    {
        categoryDataServicesMock.Setup(x => x.GetById(productDto.CategoryId)).Returns(product.Category);
        userDataServicesMock.Setup(x => x.GetById(productDto.OwnerId)).Returns(product.Owner);
        productDataServicesMock.Setup(x => x.GetUserProductDescriptions(It.IsAny<int>()))
            .Returns(new List<string> { product.Description });

        productService.Insert(productDto);
    }

    [TestMethod]
    [ExpectedException(typeof(TooManyProductsException))]
    public void TestProductInsertTooManyProductsException()
    {
        productDataServicesMock.Setup(x => x.GetActiveUserProductsCount(It.IsAny<int>())).Returns(int.MaxValue);

        productService.Insert(productDto);
    }

    [TestMethod]
    public void TestProductUpdate()
    {
        productDataServicesMock.Setup(x => x.GetById(product.Id)).Returns(product);
        categoryDataServicesMock.Setup(x => x.GetById(productDto.CategoryId)).Returns(product.Category);
        userDataServicesMock.Setup(x => x.GetById(productDto.OwnerId)).Returns(product.Owner);
        productDataServicesMock.Setup(x => x.Update(It.IsAny<Product>())).Returns(product);

        var result = productService.Update(productDto);

        Assert.AreEqual(productDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestProductUpdateNotFound()
    {
        productDataServicesMock.Setup(x => x.GetById(product.Id)).Returns(nullProduct);
        productService.Update(productDto);
    }
}