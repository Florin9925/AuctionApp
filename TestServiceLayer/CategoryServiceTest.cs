// <copyright file="CategoryServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestServiceLayer;

using DataMapper;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

/// <summary>
/// CategoryServiceTest.
/// </summary>
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

    private int iNVALIDID = -1;

    private int vALIDID = 1;

    private Mock<ICategoryDataServices> categoryDataServicesMock;

    private Mock<ILogger<CategoryServiceImpl>> loggerMock;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        this.categoryParent = new Category
        {
            Id = 1,
            Name = "Parent Category",
        };

        this.category = new Category
        {
            Id = 2,
            Name = "Category 1",
        };

        this.categoryChild = new Category
        {
            Id = 3,
            Name = "Child Category",
        };

        this.categoryChild.ParentCategories.Add(this.category);
        this.categoryParent.ChildCategories.Add(this.category);
        this.category.ParentCategories.Add(this.categoryParent);
        this.category.ChildCategories.Add(this.categoryChild);

        this.categoryDto = new CategoryDto(this.category);
        this.categoryParentDto = new CategoryDto(this.categoryParent);
        this.categoryChildDto = new CategoryDto(this.categoryChild);

        this.invalidCategoryDto = new CategoryDto
        {
            Id = this.iNVALIDID,
            Name = string.Empty,
        };

        this.notFoundCategoryDto = new CategoryDto
        {
            Id = int.MaxValue,
            Name = "Not Found Category",
        };

        this.categoryDataServicesMock = new Mock<ICategoryDataServices>();
        this.loggerMock = new Mock<ILogger<CategoryServiceImpl>>();

        this.categoryService = new CategoryServiceImpl(
            this.categoryDataServicesMock.Object,
            this.loggerMock.Object,
            new CategoryDtoValidator());
    }

    /// <summary>
    /// Tests the get all categories.
    /// </summary>
    [TestMethod]
    public void TestGetAllCategories()
    {
        this.categoryDataServicesMock.Setup(x => x.GetAll())
            .Returns(new List<Category> { this.category, this.categoryParent, this.categoryChild });

        var result = this.categoryService.GetAll();

        CollectionAssert.AreEquivalent(
            result.ToList(),
            new List<CategoryDto> { this.categoryDto, this.categoryParentDto, this.categoryChildDto });
    }

    /// <summary>
    /// Tests the get category by identifier.
    /// </summary>
    [TestMethod]
    public void TestGetCategoryById()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.vALIDID))
            .Returns(this.category);

        var result = this.categoryService.GetById(this.vALIDID);

        Assert.AreEqual(result, categoryDto);
    }

    /// <summary>
    /// Tests the get category by identifier not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<CategoryDto>))]
    public void TestGetCategoryByIdNotFound()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.iNVALIDID))
            .Returns(this.nullCategory);

        this.categoryService.GetById(this.iNVALIDID);
    }

    /// <summary>
    /// Tests the insert category.
    /// </summary>
    [TestMethod]
    public void TestInsertCategory()
    {
        this.categoryDataServicesMock.Setup(x => x.Insert(It.IsAny<Category>()))
            .Returns(this.category);

        Assert.AreEqual(this.categoryService.Insert(this.categoryDto), this.categoryDto);
    }

    /// <summary>
    /// Tests the insert category null.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestInsertCategoryNull()
    {
        this.categoryService.Insert(this.nullCategoryDto);
    }

    /// <summary>
    /// Tests the insert category invalid.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestInsertCategoryInvalid()
    {
        this.categoryService.Insert(this.invalidCategoryDto);
    }

    /// <summary>
    /// Tests the update category null.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestUpdateCategoryNull()
    {
        this.categoryService.Update(this.nullCategoryDto);
    }

    /// <summary>
    /// Tests the update category invalid.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestUpdateCategoryInvalid()
    {
        this.categoryService.Update(this.invalidCategoryDto);
    }

    /// <summary>
    /// Tests the update category not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<CategoryDto>))]
    public void TestUpdateCategoryNotFound()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.iNVALIDID))
            .Returns(this.nullCategory);

        this.categoryService.Update(this.notFoundCategoryDto);
    }

    /// <summary>
    /// Tests the update category.
    /// </summary>
    [TestMethod]
    public void TestUpdateCategory()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.category.Id))
            .Returns(this.category);

        this.categoryDataServicesMock.Setup(x => x.GetById(this.categoryParent.Id))
            .Returns(this.categoryParent);

        this.categoryDataServicesMock.Setup(x => x.GetById(this.categoryChild.Id))
            .Returns(this.categoryChild);

        this.categoryDataServicesMock.Setup(x => x.Update(It.IsAny<Category>()))
            .Returns(this.category);

        Assert.AreEqual(this.categoryService.Update(this.categoryDto), this.categoryDto);
    }

    /// <summary>
    /// Tests the delete by identifier category not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<CategoryDto>))]
    public void TestDeleteByIdCategoryNotFound()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.notFoundCategoryDto.Id)).Returns(this.nullCategory);

        this.categoryService.DeleteById(this.notFoundCategoryDto.Id);
    }

    /// <summary>
    /// Tests the delete by identifier category.
    /// </summary>
    [TestMethod]
    public void TestDeleteByIdCategory()
    {
        this.categoryDataServicesMock.Setup(x => x.GetById(this.category.Id)).Returns(this.category);

        this.categoryService.DeleteById(this.category.Id);
        Assert.IsTrue(true);
    }
}