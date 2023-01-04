using DomainModel.Dto;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Dto;

[TestFixture]
public class RoleDtoTest
{
    private RoleDtoValidator _validator;
    
    [SetUp]
    public void SetUp()
    {
        _validator = new RoleDtoValidator();
    }
    
    [Test]
    public void RoleDtoNameIsNull()
    {
        var role = new RoleDto
        {
            Name = null
        };
        var result = _validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Name);
    }

    [Test]
    public void RoleDtoNameIsEmpty()
    {
        var role = new RoleDto
        {
            Name = ""
        };
        var result = _validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Name);
    }

    [Test]
    public void RoleDtoNameIsNotEmpty()
    {
        var role = new RoleDto
        {
            Name = "Test"
        };
        var result = _validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Name);
    }

    [Test]
    public void RoleDtoIdInvalid()
    {
        var role = new RoleDto
        {
            Id = -1
        };
        var result = _validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Id);
    }

    [Test]
    public void RoleDtoIdValid()
    {
        var role = new RoleDto
        {
            Id = 0
        };
        var result = _validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Id);
    }
}