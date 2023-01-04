using DomainModel.Dto;
using DomainModel.Enum;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Dto;

[TestFixture]
public class ProductDtoTest
{
    private ProductDtoValidator _validator;
    
    [SetUp]
    public void SetUp()
    {
        _validator = new ProductDtoValidator();
    }
    
    [Test]
    public void ProductDtoNameIsNull()
    {
        var product = new ProductDto
        {
            Name = null
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    [Test]
    public void ProductDtoNameIsEmpty()
    {
        var product = new ProductDto
        {
            Name = ""
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Name);
    }

    [Test]
    public void ProductDtoNameIsNotEmpty()
    {
        var product = new ProductDto
        {
            Name = "Test"
        };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Name);
    }

    [Test]
    public void ProductDtoIdInvalid()
    {
        var product = new ProductDto
        {
            Id = -1
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    [Test]
    public void ProductDtoIdValid()
    {
        var product = new ProductDto
        {
            Id = 0
        };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Id);
    }

    [Test]
    public void ProductDtoDescriptionValid()
    {
        var product = new ProductDto
        {
            Description = "Test Description"
        };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Description);
    }

    [Test]
    public void ProductDtoDescriptionIsNull()
    {
        var product = new ProductDto
        {
            Description = null
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    [Test]
    public void ProductDtoDescriptionHasInvalidSize()
    {
        var product = new ProductDto
        {
            Description = "1"
        };
        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Description);
    }

    [Test]
    public void ProductDtoStartDateAndEndDateAreValid()
    {
        var product = new ProductDto
        {
            StartDate = DateTime.Today.AddDays(1),
            EndDate = DateTime.Today.AddDays(2)
        };
        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.StartDate);
        result.ShouldNotHaveValidationErrorFor(p => p.EndDate);
    }

    [Test]
    public void ProductDtoStartDateIsInPast()
    {
        var product = new ProductDto
        {
            StartDate = DateTime.Today.AddDays(-1)
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.StartDate);
    }

    [Test]
    public void ProductDtoStartDateIsAfterEndDate()
    {
        var product = new ProductDto
        {
            StartDate = DateTime.Today.AddDays(2),
            EndDate = DateTime.Today.AddDays(1)
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.StartDate);
    }

    [Test]
    public void ProductDtoOwnerIdIsValid()
    {
        var product = new ProductDto
        {
            OwnerId = 1
        };

        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.OwnerId);
    }

    [Test]
    public void ProductDtoOwnerIdIsInvalid()
    {
        var product = new ProductDto
        {
            OwnerId = 0
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.OwnerId);
    }

    [Test]
    public void ProductDtoAmountIsInvalid()
    {
        var product = new ProductDto
        {
            Amount = 0
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Amount);
    }

    [Test]
    public void ProductDtoAmountIsValid()
    {
        var product = new ProductDto
        {
            Amount = 1
        };

        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Amount);
    }

    [Test]
    public void ProductDtoCurrencyIsValid()
    {
        var product = new ProductDto
        {
            Currency = 0
        };

        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.Currency);
    }

    [Test]
    public void ProductDtoCurrencyIsInvalid()
    {
        var product = new ProductDto
        {
            Currency = (Currency)3
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.Currency);
    }
}