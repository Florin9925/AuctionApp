// <copyright file="ProductDtoTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Dto;

using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using DomainModel.Enum;
using FluentValidation.TestHelper;

/// <summary>
/// ProductDtoTest.
/// </summary>
[TestFixture]
public class ProductDtoTest
{
    private ProductDtoValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new ProductDtoValidator();
    }

    /// <summary>
    /// Products the dto name is null.
    /// </summary>
    [Test]
    public void ProductDtoNameIsNull()
    {
        var product = new ProductDto
        {
            Name = null,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    /// <summary>
    /// Products the dto name is empty.
    /// </summary>
    [Test]
    public void ProductDtoNameIsEmpty()
    {
        var product = new ProductDto
        {
            Name = string.Empty,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    /// <summary>
    /// Products the dto name is not empty.
    /// </summary>
    [Test]
    public void ProductDtoNameIsNotEmpty()
    {
        var product = new ProductDto
        {
            Name = "Test",
        };
        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Name);
    }

    /// <summary>
    /// Products the dto identifier invalid.
    /// </summary>
    [Test]
    public void ProductDtoIdInvalid()
    {
        var product = new ProductDto
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    /// <summary>
    /// Products the dto identifier valid.
    /// </summary>
    [Test]
    public void ProductDtoIdValid()
    {
        var product = new ProductDto
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Id);
    }

    /// <summary>
    /// Products the dto description valid.
    /// </summary>
    [Test]
    public void ProductDtoDescriptionValid()
    {
        var product = new ProductDto
        {
            Description = "Test Description",
        };
        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Description);
    }

    /// <summary>
    /// Products the dto description is null.
    /// </summary>
    [Test]
    public void ProductDtoDescriptionIsNull()
    {
        var product = new ProductDto
        {
            Description = null,
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    /// <summary>
    /// Products the size of the dto description has invalid.
    /// </summary>
    [Test]
    public void ProductDtoDescriptionHasInvalidSize()
    {
        var product = new ProductDto
        {
            Description = "1",
        };
        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    /// <summary>
    /// Products the dto start date and end date are valid.
    /// </summary>
    [Test]
    public void ProductDtoStartDateAndEndDateAreValid()
    {
        var product = new ProductDto
        {
            StartDate = DateTime.Today.AddDays(1),
            EndDate = DateTime.Today.AddDays(2),
        };
        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.StartDate);
        result.ShouldNotHaveValidationErrorFor(p => p.EndDate);
    }

    /// <summary>
    /// Products the dto start date is in past.
    /// </summary>
    [Test]
    public void ProductDtoStartDateIsInPast()
    {
        var product = new ProductDto
        {
            StartDate = DateTime.Today.AddDays(-1),
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.StartDate);
    }

    /// <summary>
    /// Products the dto start date is after end date.
    /// </summary>
    [Test]
    public void ProductDtoStartDateIsAfterEndDate()
    {
        var product = new ProductDto
        {
            StartDate = DateTime.Today.AddDays(2),
            EndDate = DateTime.Today.AddDays(1),
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.StartDate);
    }

    /// <summary>
    /// Products the dto owner identifier is valid.
    /// </summary>
    [Test]
    public void ProductDtoOwnerIdIsValid()
    {
        var product = new ProductDto
        {
            OwnerId = 1,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.OwnerId);
    }

    /// <summary>
    /// Products the dto owner identifier is invalid.
    /// </summary>
    [Test]
    public void ProductDtoOwnerIdIsInvalid()
    {
        var product = new ProductDto
        {
            OwnerId = 0,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.OwnerId);
    }

    /// <summary>
    /// Products the dto amount is invalid.
    /// </summary>
    [Test]
    public void ProductDtoAmountIsInvalid()
    {
        var product = new ProductDto
        {
            Amount = 0,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Amount);
    }

    /// <summary>
    /// Products the dto amount is valid.
    /// </summary>
    [Test]
    public void ProductDtoAmountIsValid()
    {
        var product = new ProductDto
        {
            Amount = 1,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Amount);
    }

    /// <summary>
    /// Products the dto initial price is invalid.
    /// </summary>
    [Test]
    public void ProductDtoInitialPriceIsInvalid()
    {
        var product = new ProductDto
        {
            InitialPrice = -1,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.InitialPrice);
    }

    /// <summary>
    /// Products the dto initial price is valid.
    /// </summary>
    [Test]
    public void ProductDtoInitialPriceIsValid()
    {
        var product = new ProductDto
        {
            InitialPrice = 1,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.InitialPrice);
    }

    /// <summary>
    /// Products the dto currency is valid.
    /// </summary>
    [Test]
    public void ProductDtoCurrencyIsValid()
    {
        var product = new ProductDto
        {
            Currency = 0,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Currency);
    }

    /// <summary>
    /// Products the dto currency is invalid.
    /// </summary>
    [Test]
    public void ProductDtoCurrencyIsInvalid()
    {
        var product = new ProductDto
        {
            Currency = (Currency)3,
        };

        var result = this.validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Currency);
    }

    /// <summary>
    /// Products the dto ctor.
    /// </summary>
    [Test]
    public void ProductDtoCtor()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Test",
            Description = "Test Description",
            StartDate = DateTime.Today.AddDays(1),
            EndDate = DateTime.Today.AddDays(2),
            Owner = new User
            {
                Id = 1,
            },
            Amount = 1,
            Currency = Currency.EURO,
            Category = new Category
            {
                Id = 1,
            },
        };

        var productDto = new ProductDto(product);
        Assert.Multiple(() =>
        {
            Assert.That(productDto.Id, Is.EqualTo(product.Id));
            Assert.That(productDto.Name, Is.EqualTo(product.Name));
            Assert.That(productDto.Description, Is.EqualTo(product.Description));
            Assert.That(productDto.StartDate, Is.EqualTo(product.StartDate));
            Assert.That(productDto.EndDate, Is.EqualTo(product.EndDate));
            Assert.That(productDto.OwnerId, Is.EqualTo(product.Owner.Id));
            Assert.That(productDto.Amount, Is.EqualTo(product.Amount));
            Assert.That(productDto.Currency, Is.EqualTo(product.Currency));
            Assert.That(productDto.CategoryId, Is.EqualTo(product.Category.Id));
        });
    }
}