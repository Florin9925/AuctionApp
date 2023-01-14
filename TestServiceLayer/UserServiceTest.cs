using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

namespace TestServiceLayer;

[TestClass]
public class UserServiceTest
{
    private User user;

    private User nullUser;

    private UserDto userDto;

    private UserDto nullUserDto;

    private UserDto notFoundUserDto;

    private IUserService userService;

    private Mock<IUserDataServices> userDataServicesMock;

    private Mock<ILogger<UserServiceImpl>> loggerMock;

    [TestInitialize]
    public void Setup()
    {
        user = new User
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Test@Test.com",
            PhoneNumber = "0722222222",
            Address = "This is a dummy address",
            Username = "TestUsername"
        };

        userDto = new UserDto(user);

        nullUser = null;
        nullUserDto = null;

        notFoundUserDto = new UserDto
        {
            Id = int.MaxValue
        };

        userDataServicesMock = new Mock<IUserDataServices>();
        loggerMock = new Mock<ILogger<UserServiceImpl>>();

        userService = new UserServiceImpl(userDataServicesMock.Object, loggerMock.Object, new UserDtoValidator());
    }

    [TestMethod]
    public void TestUserGetAll()
    {
        userDataServicesMock.Setup(x => x.GetAll()).Returns(new List<User> { user });

        var result = userService.GetAll();

        CollectionAssert.AreEquivalent(new List<UserDto> { userDto }, result.ToList());
    }

    [TestMethod]
    public void TestUserGetByIdValid()
    {
        userDataServicesMock.Setup(x => x.GetById(user.Id)).Returns(user);

        var result = userService.GetById(user.Id);

        Assert.AreEqual(result, userDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestUserGetByIdInvalid()
    {
        userDataServicesMock.Setup(x => x.GetById(notFoundUserDto.Id)).Returns(nullUser);

        var result = userService.GetById(notFoundUserDto.Id);

        Assert.AreEqual(result, nullUserDto);
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestUserInsertInvalidUser()
    {
        userService.Insert(notFoundUserDto);
    }

    [TestMethod]
    public void TestUserInsertValid()
    {
        userDataServicesMock.Setup(x => x.Insert(It.IsAny<User>())).Returns(user);
        var result = userService.Insert(userDto);

        Assert.AreEqual(result, userDto);
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestUserUpdateInvalidUser()
    {
        userService.Update(notFoundUserDto);
    }

    [TestMethod]
    public void TestUserUpdateValid()
    {
        userDataServicesMock.Setup(x => x.GetById(user.Id)).Returns(user);
        userDataServicesMock.Setup(x => x.Update(It.IsAny<User>())).Returns(user);
        var result = userService.Update(userDto);

        Assert.AreEqual(result, userDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestUserUpdateNotFound()
    {
        userDataServicesMock.Setup(x => x.GetById(user.Id)).Returns(nullUser);
        userService.Update(userDto);
    }
    
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestUserDeleteInvalidUser()
    {
        userDataServicesMock.Setup(x => x.GetById(notFoundUserDto.Id)).Returns(nullUser);
        userService.DeleteById(notFoundUserDto.Id);
    }

    [TestMethod]
    public void TestUserDeleteValid()
    {
        userDataServicesMock.Setup(x => x.GetById(user.Id)).Returns(user);
        userService.DeleteById(user.Id);
        
        Assert.IsTrue(true);
    }
}