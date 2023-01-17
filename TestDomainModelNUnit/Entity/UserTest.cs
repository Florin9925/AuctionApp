// <copyright file="UserTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Entity;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation.TestHelper;

/// <summary>
/// UserTest.
/// </summary>
[TestFixture]
public class UserTest
{
    private UserValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new UserValidator();
    }

    /// <summary>
    /// Users the identifier invalid.
    /// </summary>
    [Test]
    public void UserIdInvalid()
    {
        var user = new User
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Id);
    }

    /// <summary>
    /// Users the identifier valid.
    /// </summary>
    [Test]
    public void UserIdValid()
    {
        var user = new User
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Id);
    }

    /// <summary>
    /// Users the first name is null.
    /// </summary>
    [Test]
    public void UserFirstNameIsNull()
    {
        var user = new User
        {
            FirstName = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.FirstName);
    }

    /// <summary>
    /// Users the first name is empty.
    /// </summary>
    [Test]
    public void UserFirstNameIsEmpty()
    {
        var user = new User
        {
            FirstName = string.Empty,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.FirstName);
    }

    /// <summary>
    /// Users the first name is valid.
    /// </summary>
    [Test]
    public void UserFirstNameIsValid()
    {
        var user = new User
        {
            FirstName = "Test",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.FirstName);
    }

    /// <summary>
    /// Users the last name is null.
    /// </summary>
    [Test]
    public void UserLastNameIsNull()
    {
        var user = new User
        {
            LastName = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.LastName);
    }

    /// <summary>
    /// Users the last name is empty.
    /// </summary>
    [Test]
    public void UserLastNameIsEmpty()
    {
        var user = new User
        {
            LastName = string.Empty,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.LastName);
    }

    /// <summary>
    /// Users the last name is valid.
    /// </summary>
    [Test]
    public void UserLastNameIsValid()
    {
        var user = new User
        {
            LastName = "Test",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.LastName);
    }

    /// <summary>
    /// Users the username is null.
    /// </summary>
    [Test]
    public void UserUsernameIsNull()
    {
        var user = new User
        {
            Username = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Username);
    }

    /// <summary>
    /// Users the username is empty.
    /// </summary>
    [Test]
    public void UserUsernameIsEmpty()
    {
        var user = new User
        {
            Username = string.Empty,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Username);
    }

    /// <summary>
    /// Users the username is valid.
    /// </summary>
    [Test]
    public void UserUsernameIsValid()
    {
        var user = new User
        {
            Username = "Test",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Username);
    }

    /// <summary>
    /// Users the email is null.
    /// </summary>
    [Test]
    public void UserEmailIsNull()
    {
        var user = new User
        {
            Email = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the email is empty.
    /// </summary>
    [Test]
    public void UserEmailIsEmpty()
    {
        var user = new User
        {
            Email = string.Empty,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the email is invalid1.
    /// </summary>
    [Test]
    public void UserEmailIsInvalid1()
    {
        var user = new User
        {
            Email = "Test@",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the email is invalid2.
    /// </summary>
    [Test]
    public void UserEmailIsInvalid2()
    {
        var user = new User
        {
            Email = "@Test.com",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the email is valid.
    /// </summary>
    [Test]
    public void UserEmailIsValid()
    {
        var user = new User
        {
            Email = "Test@Test.com",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the address is null.
    /// </summary>
    [Test]
    public void UserAddressIsNull()
    {
        var user = new User
        {
            Address = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Address);
    }

    /// <summary>
    /// Users the address is empty.
    /// </summary>
    [Test]
    public void UserAddressIsEmpty()
    {
        var user = new User
        {
            Address = string.Empty,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Address);
    }

    /// <summary>
    /// Users the address is valid.
    /// </summary>
    [Test]
    public void UserAddressIsValid()
    {
        var user = new User
        {
            Address = "Test",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Address);
    }

    /// <summary>
    /// Users the phone number is null.
    /// </summary>
    [Test]
    public void UserPhoneNumberIsNull()
    {
        var user = new User
        {
            PhoneNumber = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    /// <summary>
    /// Users the phone number is empty.
    /// </summary>
    [Test]
    public void UserPhoneNumberIsEmpty()
    {
        var user = new User
        {
            PhoneNumber = string.Empty,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    /// <summary>
    /// Users the phone number is invalid.
    /// </summary>
    [Test]
    public void UserPhoneNumberIsInvalid()
    {
        var user = new User
        {
            PhoneNumber = "01234",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    /// <summary>
    /// Users the phone number is valid.
    /// </summary>
    [Test]
    public void UserPhoneNumberIsValid()
    {
        var user = new User
        {
            PhoneNumber = "0722-222-222",
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.PhoneNumber);
    }

    /// <summary>
    /// Users the products is null.
    /// </summary>
    [Test]
    public void UserProductsIsNull()
    {
        var user = new User
        {
            Products = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Products);
    }

    /// <summary>
    /// Users the products is not null.
    /// </summary>
    [Test]
    public void UserProductsIsNotNull()
    {
        var user = new User
        {
            Products = new List<Product>(),
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Products);
    }

    /// <summary>
    /// Users the roles is null.
    /// </summary>
    [Test]
    public void UserRolesIsNull()
    {
        var user = new User
        {
            Roles = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Roles);
    }

    /// <summary>
    /// Users the roles is not null.
    /// </summary>
    [Test]
    public void UserRolesIsNotNull()
    {
        var user = new User
        {
            Roles = new List<Role>(),
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Roles);
    }

    /// <summary>
    /// Users the get scores is null.
    /// </summary>
    [Test]
    public void UserGetScoresIsNull()
    {
        var user = new User
        {
            GetScores = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.GetScores);
    }

    /// <summary>
    /// Users the get scores is not null.
    /// </summary>
    [Test]
    public void UserGetScoresIsNotNull()
    {
        var user = new User
        {
            GetScores = new List<Score>(),
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.GetScores);
    }

    /// <summary>
    /// Users the given scores is null.
    /// </summary>
    [Test]
    public void UserGivenScoresIsNull()
    {
        var user = new User
        {
            GivenScores = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.GivenScores);
    }

    /// <summary>
    /// Users the given scores is not null.
    /// </summary>
    [Test]
    public void UserGivenScoresIsNotNull()
    {
        var user = new User
        {
            GivenScores = new List<Score>(),
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.GivenScores);
    }

    /// <summary>
    /// Users the offers is null.
    /// </summary>
    [Test]
    public void UserOffersIsNull()
    {
        var user = new User
        {
            Offers = null,
        };
        var result = this.validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Offers);
    }

    /// <summary>
    /// Users the offers is not null.
    /// </summary>
    [Test]
    public void UserOffersIsNotNull()
    {
        var user = new User
        {
            Offers = new List<Offer>(),
        };
        var result = this.validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Offers);
    }
}