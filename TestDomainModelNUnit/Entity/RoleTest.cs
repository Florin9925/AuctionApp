using DomainModel.Entity;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Entity;

[TestFixture]
public class RoleTest
{
    private RoleValidator _validator;
    
    [SetUp]
    public void SetUp()
    {
        _validator = new RoleValidator();
    }
    
    [Test]
    public void RoleNameIsNull()
    {
        var role = new Role
        {
            Name = null
        };
        var result = _validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Name);
    }

    [Test]
    public void RoleNameIsEmpty()
    {
        var role = new Role
        {
            Name = ""
        };
        var result = _validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Name);
    }

    [Test]
    public void RoleNameIsNotEmpty()
    {
        var role = new Role
        {
            Name = "Test"
        };
        var result = _validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Name);
    }

    [Test]
    public void RoleIdInvalid()
    {
        var role = new Role
        {
            Id = -1
        };
        var result = _validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Id);
    }

    [Test]
    public void RoleIdValid()
    {
        var role = new Role
        {
            Id = 0
        };
        var result = _validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Id);
    }
}