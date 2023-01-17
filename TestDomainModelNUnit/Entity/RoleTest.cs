// <copyright file="RoleTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Entity;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation.TestHelper;

/// <summary>
/// RoleTest.
/// </summary>
[TestFixture]
public class RoleTest
{
    private RoleValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new RoleValidator();
    }

    /// <summary>
    /// Roles the name is null.
    /// </summary>
    [Test]
    public void RoleNameIsNull()
    {
        var role = new Role
        {
            Name = null,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Name);
    }

    /// <summary>
    /// Roles the name is empty.
    /// </summary>
    [Test]
    public void RoleNameIsEmpty()
    {
        var role = new Role
        {
            Name = string.Empty,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Name);
    }

    /// <summary>
    /// Roles the name is not empty.
    /// </summary>
    [Test]
    public void RoleNameIsNotEmpty()
    {
        var role = new Role
        {
            Name = "Test",
        };
        var result = this.validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Name);
    }

    /// <summary>
    /// Roles the identifier invalid.
    /// </summary>
    [Test]
    public void RoleIdInvalid()
    {
        var role = new Role
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Id);
    }

    /// <summary>
    /// Roles the identifier valid.
    /// </summary>
    [Test]
    public void RoleIdValid()
    {
        var role = new Role
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Id);
    }

    /// <summary>
    /// Roles the users is null.
    /// </summary>
    [Test]
    public void RoleUsersIsNull()
    {
        var role = new Role
        {
            Users = null,
        };
        var result = this.validator.TestValidate(role);
        result.ShouldHaveValidationErrorFor(r => r.Users);
    }

    /// <summary>
    /// Roles the users is not null.
    /// </summary>
    [Test]
    public void RoleUsersIsNotNull()
    {
        var role = new Role
        {
            Users = new List<User>(),
        };
        var result = this.validator.TestValidate(role);
        result.ShouldNotHaveValidationErrorFor(r => r.Users);
    }
}