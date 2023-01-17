// <copyright file="RoleDtoTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Dto;

using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation.TestHelper;

/// <summary>
/// RoleDtoTest.
/// </summary>
[TestFixture]
public class RoleDtoTest
{
    private RoleDtoValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new RoleDtoValidator();
    }

    /// <summary>
    /// Roles the dto name is null.
    /// </summary>
    [Test]
    public void RoleDtoNameIsNull()
    {
        var role = new RoleDto
        {
            Name = null,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Name);
    }

    /// <summary>
    /// Roles the dto name is empty.
    /// </summary>
    [Test]
    public void RoleDtoNameIsEmpty()
    {
        var role = new RoleDto
        {
            Name = string.Empty,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Name);
    }

    /// <summary>
    /// Roles the dto name is not empty.
    /// </summary>
    [Test]
    public void RoleDtoNameIsNotEmpty()
    {
        var role = new RoleDto
        {
            Name = "Test",
        };
        var result = this.validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Name);
    }

    /// <summary>
    /// Roles the dto identifier invalid.
    /// </summary>
    [Test]
    public void RoleDtoIdInvalid()
    {
        var role = new RoleDto
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Id);
    }

    /// <summary>
    /// Roles the dto identifier valid.
    /// </summary>
    [Test]
    public void RoleDtoIdValid()
    {
        var role = new RoleDto
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Id);
    }

    /// <summary>
    /// Roles the dto ctor.
    /// </summary>
    [Test]
    public void RoleDtoCtor()
    {
        var role = new Role
        {
            Id = 1,
            Name = "Test",
        };

        var roleDto = new RoleDto(role);

        Assert.Multiple(() =>
        {
            Assert.That(roleDto.Id, Is.EqualTo(role.Id));
            Assert.That(roleDto.Name, Is.EqualTo(role.Name));
        });
    }
}