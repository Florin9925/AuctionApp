using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Dto;

[TestFixture]
public class UserDtoTest
{
    private UserDtoValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new UserDtoValidator();
    }

    [Test]
    public void UserDtoIdInvalid()
    {
        var userDto = new UserDto
        {
            Id = -1
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Id);
    }

    [Test]
    public void UserDtoIdValid()
    {
        var userDto = new UserDto
        {
            Id = 0
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.Id);
    }

    [Test]
    public void UserDtoFirstNameIsNull()
    {
        var userDto = new UserDto
        {
            FirstName = null
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.FirstName);
    }

    [Test]
    public void UserDtoFirstNameIsEmpty()
    {
        var userDto = new UserDto
        {
            FirstName = ""
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.FirstName);
    }

    [Test]
    public void UserDtoFirstNameIsValid()
    {
        var userDto = new UserDto
        {
            FirstName = "Test"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.FirstName);
    }

    [Test]
    public void UserDtoLastNameIsNull()
    {
        var userDto = new UserDto
        {
            LastName = null
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.LastName);
    }

    [Test]
    public void UserDtoLastNameIsEmpty()
    {
        var userDto = new UserDto
        {
            LastName = ""
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.LastName);
    }

    [Test]
    public void UserDtoLastNameIsValid()
    {
        var userDto = new UserDto
        {
            LastName = "Test"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.LastName);
    }

    [Test]
    public void UserDtoUsernameIsNull()
    {
        var userDto = new UserDto
        {
            Username = null
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Username);
    }

    [Test]
    public void UserDtoUsernameIsEmpty()
    {
        var userDto = new UserDto
        {
            Username = ""
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Username);
    }

    [Test]
    public void UserDtoUsernameIsValid()
    {
        var userDto = new UserDto
        {
            Username = "Test"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.Username);
    }

    [Test]
    public void UserDtoEmailIsNull()
    {
        var userDto = new UserDto
        {
            Email = null
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    [Test]
    public void UserDtoEmailIsEmpty()
    {
        var userDto = new UserDto
        {
            Email = ""
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    [Test]
    public void UserDtoEmailIsInvalid1()
    {
        var userDto = new UserDto
        {
            Email = "Test@"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    [Test]
    public void UserDtoEmailIsInvalid2()
    {
        var userDto = new UserDto
        {
            Email = "@Test.com"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }

    [Test]
    public void UserDtoEmailIsValid()
    {
        var userDto = new UserDto
        {
            Email = "Test@Test.com"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.Email);
    }

    [Test]
    public void UserDtoAddressIsNull()
    {
        var userDto = new UserDto
        {
            Address = null
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Address);
    }

    [Test]
    public void UserDtoAddressIsEmpty()
    {
        var userDto = new UserDto
        {
            Address = ""
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.Address);
    }

    [Test]
    public void UserDtoAddressIsValid()
    {
        var userDto = new UserDto
        {
            Address = "Test"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.Address);
    }

    [Test]
    public void UserDtoPhoneNumberIsNull()
    {
        var userDto = new UserDto
        {
            PhoneNumber = null
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    [Test]
    public void UserDtoPhoneNumberIsEmpty()
    {
        var userDto = new UserDto
        {
            PhoneNumber = ""
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    [Test]
    public void UserDtoPhoneNumberIsInvalid()
    {
        var userDto = new UserDto
        {
            PhoneNumber = "01234"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }

    [Test]
    public void UserDtoPhoneNumberIsValid()
    {
        var userDto = new UserDto
        {
            PhoneNumber = "0722-222-222"
        };
        var result = _validator.TestValidate(userDto);
        result.ShouldNotHaveValidationErrorFor(u => u.PhoneNumber);
    }

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
            Email = "Test@Test.com"
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