using DomainModel.Entity;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Entity;

[TestFixture]
public class CategoryTest
{
    private CategoryValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new CategoryValidator();
    }

    [Test]
    public void CategoryNameIsNull()
    {
        var category = new Category
        {
            Name = null
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryNameIsEmpty()
    {
        var category = new Category
        {
            Name = ""
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryNameIsNotEmpty()
    {
        var category = new Category
        {
            Name = "Test"
        };
        var result = _validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.Name);
    }

    [Test]
    public void CategoryIdInvalid()
    {
        var category = new Category
        {
            Id = -1
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Id);
    }

    [Test]
    public void CategoryIdValid()
    {
        var category = new Category
        {
            Id = 0
        };
        var result = _validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.Id);
    }
}