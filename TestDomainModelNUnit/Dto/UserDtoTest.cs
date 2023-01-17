// <copyright file="UserDtoTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Dto;

using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation.TestHelper;

/// <summary>
/// UserDtoTest.
/// </summary>
[TestFixture]
public class UserDtoTest
{
    private UserDtoValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new UserDtoValidator();
    }

    /// <summary>
    /// Users the dto identifier invalid.
    /// </summary>
    [Test]
    public void UserDtoIdInvalid()
    {
        var userDto = new UserDto
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Id);
    }

    /// <summary>
    /// Users the dto identifier valid.
    /// </summary>
    [Test]
    public void UserDtoIdValid()
    {
        var userDto = new UserDto
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.Id);
    }

    /// <summary>
    /// Users the dto first name is null.
    /// </summary>
    [Test]
    public void UserDtoFirstNameIsNull()
    {
        var userDto = new UserDto
        {
            FirstName = null,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.FirstName);
    }

    /// <summary>
    /// Users the dto first name is empty.
    /// </summary>
    [Test]
    public void UserDtoFirstNameIsEmpty()
    {
        var userDto = new UserDto
        {
            FirstName = string.Empty,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.FirstName);
    }

    /// <summary>
    /// Users the dto first name is valid.
    /// </summary>
    [Test]
    public void UserDtoFirstNameIsValid()
    {
        var userDto = new UserDto
        {
            FirstName = "Test",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.FirstName);
    }

    /// <summary>
    /// Users the dto last name is null.
    /// </summary>
    [Test]
    public void UserDtoLastNameIsNull()
    {
        var userDto = new UserDto
        {
            LastName = null,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.LastName);
    }

    /// <summary>
    /// Users the dto last name is empty.
    /// </summary>
    [Test]
    public void UserDtoLastNameIsEmpty()
    {
        var userDto = new UserDto
        {
            LastName = string.Empty,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.LastName);
    }

    /// <summary>
    /// Users the dto last name is valid.
    /// </summary>
    [Test]
    public void UserDtoLastNameIsValid()
    {
        var userDto = new UserDto
        {
            LastName = "Test",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.LastName);
    }

    /// <summary>
    /// Users the dto username is null.
    /// </summary>
    [Test]
    public void UserDtoUsernameIsNull()
    {
        var userDto = new UserDto
        {
            Username = null,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Username);
    }

    /// <summary>
    /// Users the dto username is empty.
    /// </summary>
    [Test]
    public void UserDtoUsernameIsEmpty()
    {
        var userDto = new UserDto
        {
            Username = string.Empty,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Username);
    }

    /// <summary>
    /// Users the dto username is valid.
    /// </summary>
    [Test]
    public void UserDtoUsernameIsValid()
    {
        var userDto = new UserDto
        {
            Username = "Test",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.Username);
    }

    /// <summary>
    /// Users the dto email is null.
    /// </summary>
    [Test]
    public void UserDtoEmailIsNull()
    {
        var userDto = new UserDto
        {
            Email = null,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the dto email is empty.
    /// </summary>
    [Test]
    public void UserDtoEmailIsEmpty()
    {
        var userDto = new UserDto
        {
            Email = string.Empty,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the dto email is invalid1.
    /// </summary>
    [Test]
    public void UserDtoEmailIsInvalid1()
    {
        var userDto = new UserDto
        {
            Email = "Test@",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the dto email is invalid2.
    /// </summary>
    [Test]
    public void UserDtoEmailIsInvalid2()
    {
        var userDto = new UserDto
        {
            Email = "@Test.com",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the dto email is valid.
    /// </summary>
    [Test]
    public void UserDtoEmailIsValid()
    {
        var userDto = new UserDto
        {
            Email = "Test@Test.com",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.Email);
    }

    /// <summary>
    /// Users the dto address is null.
    /// </summary>
    [Test]
    public void UserDtoAddressIsNull()
    {
        var userDto = new UserDto
        {
            Address = null,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Address);
    }

    /// <summary>
    /// Users the dto address is empty.
    /// </summary>
    [Test]
    public void UserDtoAddressIsEmpty()
    {
        var userDto = new UserDto
        {
            Address = string.Empty,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Address);
    }

    /// <summary>
    /// Users the dto address is valid.
    /// </summary>
    [Test]
    public void UserDtoAddressIsValid()
    {
        var userDto = new UserDto
        {
            Address = "Test",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.Address);
    }

    /// <summary>
    /// Users the dto phone number is null.
    /// </summary>
    [Test]
    public void UserDtoPhoneNumberIsNull()
    {
        var userDto = new UserDto
        {
            PhoneNumber = null,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    /// <summary>
    /// Users the dto phone number is empty.
    /// </summary>
    [Test]
    public void UserDtoPhoneNumberIsEmpty()
    {
        var userDto = new UserDto
        {
            PhoneNumber = string.Empty,
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    /// <summary>
    /// Users the dto phone number is invalid.
    /// </summary>
    [Test]
    public void UserDtoPhoneNumberIsInvalid()
    {
        var userDto = new UserDto
        {
            PhoneNumber = "01234",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    /// <summary>
    /// Users the dto phone number is valid.
    /// </summary>
    [Test]
    public void UserDtoPhoneNumberIsValid()
    {
        var userDto = new UserDto
        {
            PhoneNumber = "0722-222-222",
        };
        var result = this.validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.PhoneNumber);
    }

    /// <summary>
    /// Users the dto ctor.
    /// </summary>
    [Test]
    public void UserDtoCtor()
    {
        var user = new User
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Test",
            Username = "Test",
            Address = "Test",
            PhoneNumber = "0722-222-222",
            Email = "Test@Test.com",
        };

        var userDto = new UserDto(user);

        Assert.Multiple(() =>
        {
            Assert.That(userDto.Id, Is.EqualTo(user.Id));
            Assert.That(userDto.FirstName, Is.EqualTo(user.FirstName));
            Assert.That(userDto.LastName, Is.EqualTo(user.LastName));
            Assert.That(userDto.Username, Is.EqualTo(user.Username));
            Assert.That(userDto.Address, Is.EqualTo(user.Address));
            Assert.That(userDto.PhoneNumber, Is.EqualTo(user.PhoneNumber));
            Assert.That(userDto.Email, Is.EqualTo(user.Email));
        });
    }
}