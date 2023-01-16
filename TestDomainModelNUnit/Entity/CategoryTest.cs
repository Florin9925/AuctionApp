using DomainModel.Entity;
using DomainModel.Entity.Validator;
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

    [Test]
    public void CategoryProductsIsNull()
    {
        var category = new Category
        {
            Products = null
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.Products);
    }

    [Test]
    public void CategoryProductsIsNotNull()
    {
        var category = new Category
        {
            Products = new List<Product>()
        };
        var result = _validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.Products);
    }

    [Test]
    public void CategoryChildCategoriesIsNull()
    {
        var category = new Category
        {
            ChildCategories = null
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.ChildCategories);
    }

    [Test]
    public void CategoryChildCategoriesIsNotNull()
    {
        var category = new Category
        {
            ChildCategories = new List<Category>()
        };
        var result = _validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.ChildCategories);
    }

    [Test]
    public void CategoryParentCategoriesIsNull()
    {
        var category = new Category
        {
            ParentCategories = null
        };
        var result = _validator.TestValidate(category);
        result.ShouldHaveValidationErrorFor(c => c.ParentCategories);
    }

    [Test]
    public void CategoryParentCategoriesIsNotNull()
    {
        var category = new Category
        {
            ParentCategories = new List<Category>()
        };
        var result = _validator.TestValidate(category);
        result.ShouldNotHaveValidationErrorFor(c => c.ParentCategories);
    }
}