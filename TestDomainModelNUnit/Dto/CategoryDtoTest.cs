using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Dto;

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
        var category = new CategoryDto
        {
            Name = null
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryDtoNameIsEmpty()
    {
        var category = new CategoryDto
        {
            Name = ""
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryDtoNameIsNotEmpty()
    {
        var category = new CategoryDto
        {
            Name = "Test"
        };
        var result = _validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryDtoIdInvalid()
    {
        var category = new CategoryDto
        {
            Id = -1
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Id);
    }

    [Test]
    public void CategoryDtoIdValid()
    {
        var category = new CategoryDto
        {
            Id = 0
        };
        var result = _validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.Id);
    }
    
    [Test]
    public void RoleDtoCtor()
    {
        var category = new Category
        {
            Id = 1,
            Name = "Test"
        };

        var categoryDto = new CategoryDto(category);

        Assert.Multiple(() =>
        {
            Assert.That(categoryDto.Id, Is.EqualTo(category.Id));
            Assert.That(categoryDto.Name, Is.EqualTo(category.Name));
        });
    }
}