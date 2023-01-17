// <copyright file="ProductTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Entity;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using DomainModel.Enum;
using FluentValidation.TestHelper;

/// <summary>
/// ProductTest.
/// </summary>
[TestFixture]
public class ProductTest
{
    private ProductValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new ProductValidator();
    }

    /// <summary>
    /// Products the name is null.
    /// </summary>
    [Test]
    public void ProductNameIsNull()
    {
        var product = new Product
        {
            Name = null,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    /// <summary>
    /// Products the name is empty.
    /// </summary>
    [Test]
    public void ProductNameIsEmpty()
    {
        var product = new Product
        {
            Name = string.Empty,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    /// <summary>
    /// Products the name is not empty.
    /// </summary>
    [Test]
    public void ProductNameIsNotEmpty()
    {
        var product = new Product
        {
            Name = "Test",
        };
        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Name);
    }

    /// <summary>
    /// Products the identifier invalid.
    /// </summary>
    [Test]
    public void ProductIdInvalid()
    {
        var product = new Product
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    /// <summary>
    /// Products the identifier valid.
    /// </summary>
    [Test]
    public void ProductIdValid()
    {
        var product = new Product
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Id);
    }

    /// <summary>
    /// Products the description valid.
    /// </summary>
    [Test]
    public void ProductDescriptionValid()
    {
        var product = new Product
        {
            Description = "Test Description",
        };
        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Description);
    }

    /// <summary>
    /// Products the description is null.
    /// </summary>
    [Test]
    public void ProductDescriptionIsNull()
    {
        var product = new Product
        {
            Description = null,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    /// <summary>
    /// Products the size of the description has invalid.
    /// </summary>
    [Test]
    public void ProductDescriptionHasInvalidSize()
    {
        var product = new Product
        {
            Description = "1",
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    /// <summary>
    /// Products the start date and end date are valid.
    /// </summary>
    [Test]
    public void ProductStartDateAndEndDateAreValid()
    {
        var product = new Product
        {
            StartDate = DateTime.Today.AddDays(1),
            EndDate = DateTime.Today.AddDays(2),
        };
        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.StartDate);
        result.ShouldNotHaveValidationErrorFor(p => p.EndDate);
    }

    /// <summary>
    /// Products the start date is in past.
    /// </summary>
    [Test]
    public void ProductStartDateIsInPast()
    {
        var product = new Product
        {
            StartDate = DateTime.Today.AddDays(-1),
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.StartDate);
    }

    /// <summary>
    /// Products the start date is after end date.
    /// </summary>
    [Test]
    public void ProductStartDateIsAfterEndDate()
    {
        var product = new Product
        {
            StartDate = DateTime.Today.AddDays(2),
            EndDate = DateTime.Today.AddDays(1),
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.StartDate);
    }

    /// <summary>
    /// Products the owner is null.
    /// </summary>
    [Test]
    public void ProductOwnerIsNull()
    {
        var product = new Product
        {
            Owner = null,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Owner);
    }

    /// <summary>
    /// Products the owner is not null.
    /// </summary>
    [Test]
    public void ProductOwnerIsNotNull()
    {
        var product = new Product
        {
            Owner = new User(),
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Owner);
    }

    /// <summary>
    /// Products the amount is invalid.
    /// </summary>
    [Test]
    public void ProductAmountIsInvalid()
    {
        var product = new Product
        {
            Amount = 0,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Amount);
    }

    /// <summary>
    /// Products the amount is valid.
    /// </summary>
    [Test]
    public void ProductAmountIsValid()
    {
        var product = new Product
        {
            Amount = 1,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Amount);
    }

    /// <summary>
    /// Products the currency is valid.
    /// </summary>
    [Test]
    public void ProductCurrencyIsValid()
    {
        var product = new Product
        {
            Currency = 0,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Currency);
    }

    /// <summary>
    /// Products the currency is invalid.
    /// </summary>
    [Test]
    public void ProductCurrencyIsInvalid()
    {
        var product = new Product
        {
            Currency = (Currency)3,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Currency);
    }

    /// <summary>
    /// Products the category is null.
    /// </summary>
    [Test]
    public void ProductCategoryIsNull()
    {
        var product = new Product
        {
            Category = null,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Category);
    }

    /// <summary>
    /// Products the category is not null.
    /// </summary>
    [Test]
    public void ProductCategoryIsNotNull()
    {
        var product = new Product
        {
            Category = new Category(),
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Category);
    }

    /// <summary>
    /// Products the offers is null.
    /// </summary>
    [Test]
    public void ProductOffersIsNull()
    {
        var product = new Product
        {
            Offers = null,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Offers);
    }

    /// <summary>
    /// Products the offers is not null.
    /// </summary>
    [Test]
    public void ProductOffersIsNotNull()
    {
        var product = new Product
        {
            Offers = new List<Offer>(),
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Offers);
    }

    /// <summary>
    /// Products the initial price is invalid.
    /// </summary>
    [Test]
    public void ProductInitialPriceIsInvalid()
    {
        var product = new Product
        {
            InitialPrice = -1,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.InitialPrice);
    }

    /// <summary>
    /// Products the initial price is valid.
    /// </summary>
    [Test]
    public void ProductInitialPriceIsValid()
    {
        var product = new Product
        {
            InitialPrice = 1,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.InitialPrice);
    }

    /// <summary>
    /// Products the is completed default false.
    /// </summary>
    [Test]
    public void ProductIsCompletedDefaultFalse()
    {
        Assert.That(new Product().IsCompleted, Is.False);
    }
}