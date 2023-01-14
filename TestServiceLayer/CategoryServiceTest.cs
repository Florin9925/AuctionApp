using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

namespace TestServiceLayer;

[TestClass]
public class CategoryServiceTest
{
    private Category category;

    private Category categoryParent;

    private Category categoryChild;

    private CategoryDto categoryDto;

    private CategoryDto categoryParentDto;

    private CategoryDto categoryChildDto;

    private CategoryDto invalidCategoryDto;

    private CategoryDto notFoundCategoryDto;

    private Category nullCategory = null;

    private CategoryDto nullCategoryDto = null;

    private ICategoryService categoryService;

    private int INVALID_ID = -1;

    private int VALID_ID = 1;

    private Mock<ICategoryDataServices> categoryDataServicesMock;

    private Mock<ILogger<CategoryServiceImpl>> loggerMock;

    [TestInitialize]
    public void Setup()
    {
        categoryParent = new Category
        {
            Id = 1,
            Name = "Parent Category",
        };

        category = new Category
        {
            Id = 2,
            Name = "Category 1",
        };

        categoryChild = new Category
        {
            Id = 3,
            Name = "Child Category",
        };

        categoryChild.ParentCategories.Add(category);
        categoryParent.ChildCategories.Add(category);
        category.ParentCategories.Add(categoryParent);
        category.ChildCategories.Add(categoryChild);

        categoryDto = new CategoryDto(category);
        categoryParentDto = new CategoryDto(categoryParent);
        categoryChildDto = new CategoryDto(categoryChild);

        invalidCategoryDto = new CategoryDto
        {
            Id = INVALID_ID,
            Name = "",
        };

        notFoundCategoryDto = new CategoryDto
        {
            Id = int.MaxValue,
            Name = "Not Found Category",
        };

        categoryDataServicesMock = new Mock<ICategoryDataServices>();
        loggerMock = new Mock<ILogger<CategoryServiceImpl>>();

        categoryService = new CategoryServiceImpl(
            categoryDataServicesMock.Object,
            loggerMock.Object,
            new CategoryDtoValidator());
    }

    [TestMethod]
    public void TestGetAllCategories()
    {
        categoryDataServicesMock.Setup(x => x.GetAll())
            .Returns(new List<Category> { category, categoryParent, categoryChild });

        var result = categoryService.GetAll();

        CollectionAssert.AreEquivalent(result.ToList(),
            new List<CategoryDto> { categoryDto, categoryParentDto, categoryChildDto });
    }

    [TestMethod]
    public void TestGetCategoryById()
    {
        categoryDataServicesMock.Setup(x => x.GetById(VALID_ID))
            .Returns(category);

        var result = categoryService.GetById(VALID_ID);

        Assert.AreEqual(result, categoryDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<CategoryDto>))]
    public void TestGetCategoryByIdNotFound()
    {
        categoryDataServicesMock.Setup(x => x.GetById(INVALID_ID))
            .Returns(nullCategory);

        var result = categoryService.GetById(INVALID_ID);

        Assert.IsNull(result);
    }

    [TestMethod]
    public void TestInsertCategory()
    {
        categoryDataServicesMock.Setup(x => x.Insert(It.IsAny<Category>()))
            .Returns(category);

        Assert.AreEqual(categoryService.Insert(categoryDto), categoryDto);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestInsertCategoryNull()
    {
        categoryService.Insert(nullCategoryDto);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestInsertCategoryInvalid()
    {
        categoryService.Insert(invalidCategoryDto);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestUpdateCategoryNull()
    {
        categoryService.Update(nullCategoryDto);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestUpdateCategoryInvalid()
    {
        categoryService.Update(invalidCategoryDto);
    }
    
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<CategoryDto>))]
    public void TestUpdateCategoryNotFound()
    {
        categoryDataServicesMock.Setup(x => x.GetById(INVALID_ID))
            .Returns(nullCategory);

        categoryService.Update(notFoundCategoryDto);
    }
    
    [TestMethod]
    public void TestUpdateCategory()
    {
        categoryDataServicesMock.Setup(x => x.GetById(category.Id))
            .Returns(category);
        
        categoryDataServicesMock.Setup(x => x.GetById(categoryParent.Id))
            .Returns(categoryParent);
        
        categoryDataServicesMock.Setup(x => x.GetById(categoryChild.Id))
            .Returns(categoryChild);

        categoryDataServicesMock.Setup(x => x.Update(It.IsAny<Category>()))
            .Returns(category);

        Assert.AreEqual(categoryService.Update(categoryDto), categoryDto);
    }
    
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<CategoryDto>))]
    public void TestDeleteByIdCategoryNotFound()
    {
        categoryDataServicesMock.Setup(x => x.GetById(notFoundCategoryDto.Id)).Returns(nullCategory);

        categoryService.DeleteById(notFoundCategoryDto.Id);
    }
    
    [TestMethod]
    public void TestDeleteByIdCategory()
    {
        categoryDataServicesMock.Setup(x => x.GetById(category.Id)).Returns(category);

        categoryService.DeleteById(category.Id);
        Assert.IsTrue(true);
    }
}