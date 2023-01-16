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
    private CategoryDtoValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new CategoryDtoValidator();
    }

    [Test]
    public void CategoryDtoNameIsNull()
    {
        var categoryDto = new CategoryDto
        {
            Name = null
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryDtoNameIsEmpty()
    {
        var categoryDto = new CategoryDto
        {
            Name = ""
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryDtoNameIsNotEmpty()
    {
        var categoryDto = new CategoryDto
        {
            Name = "Test"
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldNotHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryDtoIdInvalid()
    {
        var categoryDto = new CategoryDto
        {
            Id = -1
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.Id);
    }

    [Test]
    public void CategoryDtoIdValid()
    {
        var categoryDto = new CategoryDto
        {
            Id = 0
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldNotHaveValidationErrorFor(c => c.Id);
    }

    [Test]
    public void CategoryDtoChildCategoriesIsNull()
    {
        var categoryDto = new CategoryDto
        {
            ChildCategoryIds = null
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.ChildCategoryIds);
    }

    [Test]
    public void CategoryDtoChildCategoriesIsNotNull()
    {
        var categoryDto = new CategoryDto
        {
            ChildCategoryIds = new List<int>()
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldNotHaveValidationErrorFor(c => c.ChildCategoryIds);
    }

    [Test]
    public void CategoryDtoParentCategoriesIsNull()
    {
        var categoryDto = new CategoryDto
        {
            ParentCategoryIds = null
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldHaveValidationErrorFor(c => c.ParentCategoryIds);
    }

    [Test]
    public void CategoryDtoParentCategoriesIsNotNull()
    {
        var categoryDto = new CategoryDto
        {
            ParentCategoryIds = new List<int>()
        };
        var result = _validator.TestValidate(categoryDto);
        result.ShouldNotHaveValidationErrorFor(c => c.ParentCategoryIds);
    }

    [Test]
    public void RoleDtoCtor()
    {
        var category = new Category
        {
            Id = 1,
            Name = "Test",
            ChildCategories = new List<Category>(),
            ParentCategories = new List<Category>()
        };

        var categoryDto = new CategoryDto(category);

        Assert.Multiple(() =>
        {
            Assert.That(categoryDto.Id, Is.EqualTo(category.Id));
            Assert.That(categoryDto.Name, Is.EqualTo(category.Name));
            Assert.That(categoryDto.ChildCategoryIds, Is.EqualTo(category.ChildCategories.Select(c=>c.Id).ToList()));
            Assert.That(categoryDto.ParentCategoryIds, Is.EqualTo(category.ChildCategories.Select(c=>c.Id).ToList()));
        });
    }
}