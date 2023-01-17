// <copyright file="RoleServiceTest.cs" company="Transilvania University of Brasov">
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
/// RoleServiceTest.
/// </summary>
[TestClass]
public class RoleServiceTest
{
    private RoleDto roleAdminDto;

    private RoleDto roleUserDto;

    private RoleDto invalidRoleDto;

    private RoleDto notFoundRoleDto;

    private Role roleAdmin;

    private Role roleUser;

    private Role nullRole = null;

    private int iNVALIDID = -1;

    private Mock<IRoleDataServices> roleDataServicesMock;

    private IRoleService roleServiceImpl;

    private Mock<ILogger<RoleServiceImpl>> loggerMock;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        this.roleAdminDto = new RoleDto
        {
            Id = 1,
            Name = "Admin",
        };

        this.roleUserDto = new RoleDto
        {
            Id = 2,
            Name = "User",
        };

        this.roleAdmin = new Role
        {
            Id = 1,
            Name = "Admin",
        };

        this.roleUser = new Role
        {
            Id = 2,
            Name = "User",
        };

        this.invalidRoleDto = new RoleDto
        {
            Id = 0,
            Name = string.Empty,
        };

        this.notFoundRoleDto = new RoleDto
        {
            Id = int.MaxValue,
            Name = "Not Found",
        };

        this.roleDataServicesMock = new Mock<IRoleDataServices>();
        this.loggerMock = new Mock<ILogger<RoleServiceImpl>>();

        this.roleServiceImpl = new RoleServiceImpl(this.roleDataServicesMock.Object, this.loggerMock.Object, new RoleDtoValidator());
    }

    /// <summary>
    /// Tests the get all.
    /// </summary>
    [TestMethod]
    public void TestGetAll()
    {
        this.roleDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Role> { this.roleAdmin, this.roleUser });

        var result = this.roleServiceImpl.GetAll();

        CollectionAssert.AreEquivalent(new List<RoleDto> { this.roleAdminDto, this.roleUserDto }, result.ToList());
    }

    /// <summary>
    /// Tests the get by identifier with valid identifier.
    /// </summary>
    [TestMethod]
    public void TestGetByIdWithValidId()
    {
        this.roleDataServicesMock.Setup(x => x.GetById(this.roleAdmin.Id)).Returns(this.roleAdmin);

        var result = this.roleServiceImpl.GetById(this.roleAdmin.Id);

        Assert.AreEqual(result, this.roleAdminDto);
    }

    /// <summary>
    /// Tests the get by identifier with invalid identifier.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<RoleDto>))]
    public void TestGetByIdWithInvalidId()
    {
        this.roleDataServicesMock.Setup(x => x.GetById(this.iNVALIDID)).Returns(this.nullRole);

        this.roleServiceImpl.GetById(this.iNVALIDID);
    }

    /// <summary>
    /// Tests the insert null role.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestInsertNullRole()
    {
        this.roleServiceImpl.Insert(null);
    }

    /// <summary>
    /// Tests the insert invalid role.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestInsertInvalidRole()
    {
        this.roleServiceImpl.Insert(this.invalidRoleDto);
    }

    /// <summary>
    /// Tests the insert valid role.
    /// </summary>
    [TestMethod]
    public void TestInsertValidRole()
    {
        this.roleDataServicesMock.Setup(x => x.Insert(It.IsAny<Role>())).Returns(this.roleAdmin);

        Assert.AreEqual(this.roleServiceImpl.Insert(this.roleAdminDto), this.roleAdminDto);
    }

    /// <summary>
    /// Tests the update null role.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestUpdateNullRole()
    {
        this.roleServiceImpl.Update(null);
    }

    /// <summary>
    /// Tests the update invalid role.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestUpdateInvalidRole()
    {
        this.roleServiceImpl.Update(this.invalidRoleDto);
    }

    /// <summary>
    /// Tests the update not found role.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<RoleDto>))]
    public void TestUpdateNotFoundRole()
    {
        this.roleDataServicesMock.Setup(x => x.GetById(this.notFoundRoleDto.Id)).Returns(this.nullRole);

        this.roleServiceImpl.Update(this.notFoundRoleDto);
    }

    /// <summary>
    /// Tests the update valid.
    /// </summary>
    [TestMethod]
    public void TestUpdateValid()
    {
        this.roleDataServicesMock.Setup(x => x.GetById(this.roleAdminDto.Id)).Returns(this.roleAdmin);

        this.roleServiceImpl.Update(this.roleAdminDto);

        this.roleDataServicesMock.Verify(x => x.Update(this.roleAdmin), Times.Once);
    }

    /// <summary>
    /// Tests the delete by identifier not found user.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<RoleDto>))]
    public void TestDeleteByIdNotFoundUser()
    {
        this.roleDataServicesMock.Setup(x => x.GetById(this.notFoundRoleDto.Id)).Returns(this.nullRole);
        this.roleServiceImpl.DeleteById(this.notFoundRoleDto.Id);
    }

    /// <summary>
    /// Tests the delete by identifier valid role.
    /// </summary>
    [TestMethod]
    public void TestDeleteByIdValidRole()
    {
        this.roleDataServicesMock.Setup(x => x.GetById(this.roleAdminDto.Id)).Returns(this.roleAdmin);
        this.roleServiceImpl.DeleteById(this.roleAdminDto.Id);
        Assert.IsTrue(true);
    }
}