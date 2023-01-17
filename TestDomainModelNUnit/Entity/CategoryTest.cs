// <copyright file="CategoryTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Entity;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation.TestHelper;

/// <summary>
/// CategoryTest.
/// </summary>
[TestFixture]
public class CategoryTest
{
    private CategoryValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new CategoryValidator();
    }

    /// <summary>
    /// Categories the name is null.
    /// </summary>
    [Test]
    public void CategoryNameIsNull()
    {
        var category = new Category
        {
            Name = null,
        };
        var result = this.validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    /// <summary>
    /// Categories the name is empty.
    /// </summary>
    [Test]
    public void CategoryNameIsEmpty()
    {
        var category = new Category
        {
            Name = string.Empty,
        };
        var result = this.validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    /// <summary>
    /// Categories the name is not empty.
    /// </summary>
    [Test]
    public void CategoryNameIsNotEmpty()
    {
        var category = new Category
        {
            Name = "Test",
        };
        var result = this.validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.Name);
    }

    /// <summary>
    /// Categories the identifier invalid.
    /// </summary>
    [Test]
    public void CategoryIdInvalid()
    {
        var category = new Category
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Id);
    }

    /// <summary>
    /// Categories the identifier valid.
    /// </summary>
    [Test]
    public void CategoryIdValid()
    {
        var category = new Category
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.Id);
    }

    /// <summary>
    /// Categories the products is null.
    /// </summary>
    [Test]
    public void CategoryProductsIsNull()
    {
        var category = new Category
        {
            Products = null,
        };
        var result = this.validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Products);
    }

    /// <summary>
    /// Categories the products is not null.
    /// </summary>
    [Test]
    public void CategoryProductsIsNotNull()
    {
        var category = new Category
        {
            Products = new List<Product>(),
        };
        var result = this.validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.Products);
    }

    /// <summary>
    /// Categories the child categories is null.
    /// </summary>
    [Test]
    public void CategoryChildCategoriesIsNull()
    {
        var category = new Category
        {
            ChildCategories = null,
        };
        var result = this.validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.ChildCategories);
    }

    /// <summary>
    /// Categories the child categories is not null.
    /// </summary>
    [Test]
    public void CategoryChildCategoriesIsNotNull()
    {
        var category = new Category
        {
            ChildCategories = new List<Category>(),
        };
        var result = this.validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.ChildCategories);
    }

    /// <summary>
    /// Categories the parent categories is null.
    /// </summary>
    [Test]
    public void CategoryParentCategoriesIsNull()
    {
        var category = new Category
        {
            ParentCategories = null,
        };
        var result = this.validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.ParentCategories);
    }

    /// <summary>
    /// Categories the parent categories is not null.
    /// </summary>
    [Test]
    public void CategoryParentCategoriesIsNotNull()
    {
        var category = new Category
        {
            ParentCategories = new List<Category>(),
        };
        var result = this.validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.ParentCategories);
    }
}