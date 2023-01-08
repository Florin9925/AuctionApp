using DomainModel.Dto;
using DomainModel.Entity;
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
    public void ProductDtoInitialPriceIsInvalid()
    {
        var product = new ProductDto
        {
            InitialPrice = -1
        };

        var result = _validator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p => p.InitialPrice);
    }

    [Test]
    public void ProductDtoInitialPriceIsValid()
    {
        var product = new ProductDto
        {
            InitialPrice = 1
        };

        var result = _validator.TestValidate(product);
        result.ShouldNotHaveValidationErrorFor(p => p.InitialPrice);
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
                Id = 1
            },
            Amount = 1,
            Currency = Currency.EURO,
            Category = new Category
            {
                Id = 1
            }
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