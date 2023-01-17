// <copyright file="UserServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestServiceLayer;

using DataMapper;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

/// <summary>
/// UserServiceTest.
/// </summary>
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

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        this.user = new User
        {
            Id = 1,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Test@Test.com",
            PhoneNumber = "0722222222",
            Address = "This is a dummy address",
            Username = "TestUsername",
        };

        this.userDto = new UserDto(this.user);

        this.nullUser = null;
        this.nullUserDto = null;

        this.notFoundUserDto = new UserDto
        {
            Id = int.MaxValue,
        };

        this.userDataServicesMock = new Mock<IUserDataServices>();
        this.loggerMock = new Mock<ILogger<UserServiceImpl>>();

        this.userService = new UserServiceImpl(this.userDataServicesMock.Object, this.loggerMock.Object, new UserDtoValidator());
    }

    /// <summary>
    /// Tests the user get all.
    /// </summary>
    [TestMethod]
    public void TestUserGetAll()
    {
        this.userDataServicesMock.Setup(x => x.GetAll()).Returns(new List<User> { this.user });

        var result = this.userService.GetAll();

        CollectionAssert.AreEquivalent(new List<UserDto> { this.userDto }, result.ToList());
    }

    /// <summary>
    /// Tests the user get by identifier valid.
    /// </summary>
    [TestMethod]
    public void TestUserGetByIdValid()
    {
        this.userDataServicesMock.Setup(x => x.GetById(this.user.Id)).Returns(this.user);

        var result = this.userService.GetById(this.user.Id);

        Assert.AreEqual(result, this.userDto);
    }

    /// <summary>
    /// Tests the user get by identifier invalid.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestUserGetByIdInvalid()
    {
        this.userDataServicesMock.Setup(x => x.GetById(this.notFoundUserDto.Id)).Returns(this.nullUser);

        var result = this.userService.GetById(this.notFoundUserDto.Id);

        Assert.AreEqual(result, this.nullUserDto);
    }

    /// <summary>
    /// Tests the user insert invalid user.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestUserInsertInvalidUser()
    {
        this.userService.Insert(this.notFoundUserDto);
    }

    /// <summary>
    /// Tests the user insert valid.
    /// </summary>
    [TestMethod]
    public void TestUserInsertValid()
    {
        this.userDataServicesMock.Setup(x => x.Insert(It.IsAny<User>())).Returns(this.user);
        var result = this.userService.Insert(this.userDto);

        Assert.AreEqual(result, this.userDto);
    }

    /// <summary>
    /// Tests the user update invalid user.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestUserUpdateInvalidUser()
    {
        this.userService.Update(this.notFoundUserDto);
    }

    /// <summary>
    /// Tests the user update valid.
    /// </summary>
    [TestMethod]
    public void TestUserUpdateValid()
    {
        this.userDataServicesMock.Setup(x => x.GetById(this.user.Id)).Returns(this.user);
        this.userDataServicesMock.Setup(x => x.Update(It.IsAny<User>())).Returns(this.user);
        var result = this.userService.Update(this.userDto);

        Assert.AreEqual(result, this.userDto);
    }

    /// <summary>
    /// Tests the user update not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestUserUpdateNotFound()
    {
        this.userDataServicesMock.Setup(x => x.GetById(this.user.Id)).Returns(this.nullUser);
        this.userService.Update(this.userDto);
    }

    /// <summary>
    /// Tests the user delete invalid user.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestUserDeleteInvalidUser()
    {
        this.userDataServicesMock.Setup(x => x.GetById(this.notFoundUserDto.Id)).Returns(this.nullUser);
        this.userService.DeleteById(this.notFoundUserDto.Id);
    }

    /// <summary>
    /// Tests the user delete valid.
    /// </summary>
    [TestMethod]
    public void TestUserDeleteValid()
    {
        this.userDataServicesMock.Setup(x => x.GetById(this.user.Id)).Returns(this.user);
        this.userService.DeleteById(this.user.Id);

        Assert.IsTrue(true);
    }
}