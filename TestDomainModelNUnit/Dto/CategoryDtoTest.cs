// <copyright file="CategoryDtoTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Dto;

using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation.TestHelper;

/// <summary>
/// CategoryDtoTest.
/// </summary>
[TestFixture]
public class CategoryDtoTest
{
    private CategoryDtoValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new CategoryDtoValidator();
    }

    /// <summary>
    /// Categories the dto name is null.
    /// </summary>
    [Test]
    public void CategoryDtoNameIsNull()
    {
        var categoryDto = new CategoryDto
        {
            Name = null,
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    /// <summary>
    /// Categories the dto name is empty.
    /// </summary>
    [Test]
    public void CategoryDtoNameIsEmpty()
    {
        var categoryDto = new CategoryDto
        {
            Name = string.Empty,
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    /// <summary>
    /// Categories the dto name is not empty.
    /// </summary>
    [Test]
    public void CategoryDtoNameIsNotEmpty()
    {
        var categoryDto = new CategoryDto
        {
            Name = "Test",
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldNotHaveValidationErrorFor(c => c.Name);
    }

    /// <summary>
    /// Categories the dto identifier invalid.
    /// </summary>
    [Test]
    public void CategoryDtoIdInvalid()
    {
        var categoryDto = new CategoryDto
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.Id);
    }

    /// <summary>
    /// Categories the dto identifier valid.
    /// </summary>
    [Test]
    public void CategoryDtoIdValid()
    {
        var categoryDto = new CategoryDto
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldNotHaveValidationErrorFor(c => c.Id);
    }

    /// <summary>
    /// Categories the dto child categories is null.
    /// </summary>
    [Test]
    public void CategoryDtoChildCategoriesIsNull()
    {
        var categoryDto = new CategoryDto
        {
            ChildCategoryIds = null,
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.ChildCategoryIds);
    }

    /// <summary>
    /// Categories the dto child categories is not null.
    /// </summary>
    [Test]
    public void CategoryDtoChildCategoriesIsNotNull()
    {
        var categoryDto = new CategoryDto
        {
            ChildCategoryIds = new List<int>(),
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldNotHaveValidationErrorFor(c => c.ChildCategoryIds);
    }

    /// <summary>
    /// Categories the dto parent categories is null.
    /// </summary>
    [Test]
    public void CategoryDtoParentCategoriesIsNull()
    {
        var categoryDto = new CategoryDto
        {
            ParentCategoryIds = null,
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.ParentCategoryIds);
    }

    /// <summary>
    /// Categories the dto parent categories is not null.
    /// </summary>
    [Test]
    public void CategoryDtoParentCategoriesIsNotNull()
    {
        var categoryDto = new CategoryDto
        {
            ParentCategoryIds = new List<int>(),
        };
        var result = this.validator.TestValidate(categoryDto);
        result.ShouldNotHaveValidationErrorFor(c => c.ParentCategoryIds);
    }

    /// <summary>
    /// Roles the dto ctor.
    /// </summary>
    [Test]
    public void RoleDtoCtor()
    {
        var category = new Category
        {
            Id = 1,
            Name = "Test",
            ChildCategories = new List<Category>(),
            ParentCategories = new List<Category>(),
        };

        var categoryDto = new CategoryDto(category);

        Assert.Multiple(() =>
        {
            Assert.That(categoryDto.Id, Is.EqualTo(category.Id));
            Assert.That(categoryDto.Name, Is.EqualTo(category.Name));
            Assert.That(categoryDto.ChildCategoryIds, Is.EqualTo(category.ChildCategories.Select(c => c.Id).ToList()));
            Assert.That(categoryDto.ParentCategoryIds, Is.EqualTo(category.ChildCategories.Select(c => c.Id).ToList()));
        });
    }
}