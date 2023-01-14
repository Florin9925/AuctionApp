using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

namespace TestServiceLayer;

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

    private int INVALID_ID = -1;

    private int VALID_ID = 1;

    private Mock<IRoleDataServices> roleDataServicesMock;

    private IRoleService roleServiceImpl;

    private Mock<ILogger<RoleServiceImpl>> loggerMock;

    [TestInitialize]
    public void Setup()
    {
        roleAdminDto = new RoleDto
        {
            Id = 1,
            Name = "Admin"
        };

        roleUserDto = new RoleDto
        {
            Id = 2,
            Name = "User"
        };

        roleAdmin = new Role
        {
            Id = 1,
            Name = "Admin"
        };

        roleUser = new Role
        {
            Id = 2,
            Name = "User"
        };

        invalidRoleDto = new RoleDto
        {
            Id = 0,
            Name = ""
        };

        notFoundRoleDto = new RoleDto
        {
            Id = int.MaxValue,
            Name = "Not Found"
        };

        roleDataServicesMock = new Mock<IRoleDataServices>();
        loggerMock = new Mock<ILogger<RoleServiceImpl>>();

        roleServiceImpl = new RoleServiceImpl(roleDataServicesMock.Object, loggerMock.Object, new RoleDtoValidator());
    }

    [TestMethod]
    public void TestGetAll()
    {
        roleDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Role> { roleAdmin, roleUser });

        var result = roleServiceImpl.GetAll();

        CollectionAssert.AreEquivalent(new List<RoleDto> { roleAdminDto, roleUserDto }, result.ToList());
    }

    [TestMethod]
    public void TestGetByIdWithValidId()
    {
        roleDataServicesMock.Setup(x => x.GetById(roleAdmin.Id)).Returns(roleAdmin);

        var result = roleServiceImpl.GetById(roleAdmin.Id);

        Assert.AreEqual(result, roleAdminDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<RoleDto>))]
    public void TestGetByIdWithInvalidId()
    {
        roleDataServicesMock.Setup(x => x.GetById(INVALID_ID)).Returns(nullRole);

        roleServiceImpl.GetById(INVALID_ID);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestInsertNullRole()
    {
        roleServiceImpl.Insert(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestInsertInvalidRole()
    {
        roleServiceImpl.Insert(invalidRoleDto);
    }

    [TestMethod]
    public void TestInsertValidRole()
    {
        roleDataServicesMock.Setup(x => x.Insert(It.IsAny<Role>())).Returns(roleAdmin);

        Assert.AreEqual(roleServiceImpl.Insert(roleAdminDto), roleAdminDto);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestUpdateNullRole()
    {
        roleServiceImpl.Update(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestUpdateInvalidRole()
    {
        roleServiceImpl.Update(invalidRoleDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<RoleDto>))]
    public void TestUpdateNotFoundRole()
    {
        roleDataServicesMock.Setup(x => x.GetById(notFoundRoleDto.Id)).Returns(nullRole);

        roleServiceImpl.Update(notFoundRoleDto);
    }

    [TestMethod]
    public void TestUpdateValid()
    {
        roleDataServicesMock.Setup(x => x.GetById(roleAdminDto.Id)).Returns(roleAdmin);

        roleServiceImpl.Update(roleAdminDto);

        roleDataServicesMock.Verify(x => x.Update(roleAdmin), Times.Once);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<RoleDto>))]
    public void TestDeleteByIdNotFoundUser()
    {
        roleDataServicesMock.Setup(x => x.GetById(notFoundRoleDto.Id)).Returns(nullRole);
        roleServiceImpl.DeleteById(notFoundRoleDto.Id);
    }

    [TestMethod]
    public void TestDeleteByIdValidRole()
    {
        roleDataServicesMock.Setup(x => x.GetById(roleAdminDto.Id)).Returns(roleAdmin);
        roleServiceImpl.DeleteById(roleAdminDto.Id);
        Assert.IsTrue(true);
    }
}