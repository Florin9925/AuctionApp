using DomainModel.Entity;
using DomainModel.Enum;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Entity;

[TestFixture]
public class ProductTest
{
    private ProductValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new ProductValidator();
    }

    [Test]
    public void ProductNameIsNull()
    {
        var product = new Product
        {
            Name = null
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    [Test]
    public void ProductNameIsEmpty()
    {
        var product = new Product
        {
            Name = ""
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    [Test]
    public void ProductNameIsNotEmpty()
    {
        var product = new Product
        {
            Name = "Test"
        };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Name);
    }

    [Test]
    public void ProductIdInvalid()
    {
        var product = new Product
        {
            Id = -1
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    [Test]
    public void ProductIdValid()
    {
        var product = new Product
        {
            Id = 0
        };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Id);
    }

    [Test]
    public void ProductDescriptionValid()
    {
        var product = new Product
        {
            Description = "Test Description"
        };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Description);
    }

    [Test]
    public void ProductDescriptionIsNull()
    {
        var product = new Product
        {
            Description = null
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    [Test]
    public void ProductDescriptionHasInvalidSize()
    {
        var product = new Product
        {
            Description = "1"
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    [Test]
    public void ProductStartDateAndEndDateAreValid()
    {
        var product = new Product
        {
            StartDate = DateTime.Today.AddDays(1),
            EndDate = DateTime.Today.AddDays(2)
        };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.StartDate);
        result.ShouldNotHaveValidationErrorFor(p => p.EndDate);
    }

    [Test]
    public void ProductStartDateIsInPast()
    {
        var product = new Product
        {
            StartDate = DateTime.Today.AddDays(-1)
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.StartDate);
    }

    [Test]
    public void ProductStartDateIsAfterEndDate()
    {
        var product = new Product
        {
            StartDate = DateTime.Today.AddDays(2),
            EndDate = DateTime.Today.AddDays(1)
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.StartDate);
    }

    [Test]
    public void ProductOwnerIsNull()
    {
        var product = new Product
        {
            Owner = null
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Owner);
    }

    [Test]
    public void ProductOwnerIsNotNull()
    {
        var product = new Product
        {
            Owner = new User()
        };

        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Owner);
    }

    [Test]
    public void ProductAmountIsInvalid()
    {
        var product = new Product
        {
            Amount = 0
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Amount);
    }

    [Test]
    public void ProductAmountIsValid()
    {
        var product = new Product
        {
            Amount = 1
        };

        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Amount);
    }

    [Test]
    public void ProductCurrencyIsValid()
    {
        var product = new Product
        {
            Currency = 0
        };

        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Currency);
    }

    [Test]
    public void ProductCurrencyIsInvalid()
    {
        var product = new Product
        {
            Currency = (Currency)3
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Currency);
    }
}