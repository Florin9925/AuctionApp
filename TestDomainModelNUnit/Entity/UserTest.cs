using DomainModel.Entity;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Entity;

[TestFixture]
public class UserTest
{
    private UserValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new UserValidator();
    }

    [Test]
    public void UserIdInvalid()
    {
        var user = new User
        {
            Id = -1
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Id);
    }

    [Test]
    public void UserIdValid()
    {
        var user = new User
        {
            Id = 0
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Id);
    }
    
    [Test]
    public void UserFirstNameIsNull()
    {
        var user = new User
        {
            FirstName = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.FirstName);
    }
    
    [Test]
    public void UserFirstNameIsEmpty()
    {
        var user = new User
        {
            FirstName = ""
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.FirstName);
    }
    
    [Test]
    public void UserFirstNameIsValid()
    {
        var user = new User
        {
            FirstName = "Test"
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.FirstName);
    }
    
    [Test]
    public void UserLastNameIsNull()
    {
        var user = new User
        {
            LastName = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.LastName);
    }
    
    [Test]
    public void UserLastNameIsEmpty()
    {
        var user = new User
        {
            LastName = ""
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.LastName);
    }
    
    [Test]
    public void UserLastNameIsValid()
    {
        var user = new User
        {
            LastName = "Test"
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.LastName);
    }
    
    [Test]
    public void UserUsernameIsNull()
    {
        var user = new User
        {
            Username = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Username);
    }
    
    [Test]
    public void UserUsernameIsEmpty()
    {
        var user = new User
        {
            Username = ""
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Username);
    }
    
    [Test]
    public void UserUsernameIsValid()
    {
        var user = new User
        {
            Username = "Test"
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Username);
    }
    
    [Test]
    public void UserEmailIsNull()
    {
        var user = new User
        {
            Email = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }
    
    [Test]
    public void UserEmailIsEmpty()
    {
        var user = new User
        {
            Email = ""
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }
    
    [Test]
    public void UserEmailIsInvalid1()
    {
        var user = new User
        {
            Email = "Test@"
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }
    
    [Test]
    public void UserEmailIsInvalid2()
    {
        var user = new User
        {
            Email = "@Test.com"
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Email);
    }
    
    [Test]
    public void UserEmailIsValid()
    {
        var user = new User
        {
            Email = "Test@Test.com"
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Email);
    }
    
    [Test]
    public void UserAddressIsNull()
    {
        var user = new User
        {
            Address = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Address);
    }
    
    [Test]
    public void UserAddressIsEmpty()
    {
        var user = new User
        {
            Address = ""
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Address);
    }
    
    [Test]
    public void UserAddressIsValid()
    {
        var user = new User
        {
            Address = "Test"
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Address);
    }
    
    [Test]
    public void UserPhoneNumberIsNull()
    {
        var user = new User
        {
            PhoneNumber = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }
    
    [Test]
    public void UserPhoneNumberIsEmpty()
    {
        var user = new User
        {
            PhoneNumber = ""
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }
    
    [Test]
    public void UserPhoneNumberIsInvalid()
    {
        var user = new User
        {
            PhoneNumber = "01234"
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
    }
    
    [Test]
    public void UserPhoneNumberIsValid()
    {
        var user = new User
        {
            PhoneNumber = "0722-222-222"
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.PhoneNumber);
    }
    
    [Test]
    public void UserProductsIsNull()
    {
        var user = new User
        {
            Products = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Products);
    }
    
    [Test]
    public void UserProductsIsNotNull()
    {
        var user = new User
        {
            Products = new List<Product>()
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Products);
    }
    
    [Test]
    public void UserRolesIsNull()
    {
        var user = new User
        {
            Roles = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Roles);
    }
    
    [Test]
    public void UserRolesIsNotNull()
    {
        var user = new User
        {
            Roles = new List<Role>()
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Roles);
    }   
    
    [Test]
    public void UserGetScoresIsNull()
    {
        var user = new User
        {
            GetScores = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.GetScores);
    }
    
    [Test]
    public void UserGetScoresIsNotNull()
    {
        var user = new User
        {
            GetScores = new List<Score>()
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.GetScores);
    }
    
    [Test]
    public void UserGivenScoresIsNull()
    {
        var user = new User
        {
            GivenScores = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.GivenScores);
    }
    
    [Test]
    public void UserGivenScoresIsNotNull()
    {
        var user = new User
        {
            GivenScores = new List<Score>()
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.GivenScores);
    }
    
    [Test]
    public void UserOffersIsNull()
    {
        var user = new User
        {
            Offers = null
        };
        var result = _validator.TestValidate(user);
        result.ShouldHaveValidationErrorFor(u => u.Offers);
    }
    
    [Test]
    public void UserOffersIsNotNull()
    {
        var user = new User
        {
            Offers = new List<Offer>()
        };
        var result = _validator.TestValidate(user);
        result.ShouldNotHaveValidationErrorFor(u => u.Offers);
    }
}