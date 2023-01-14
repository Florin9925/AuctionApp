using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceLayer.ServiceImplementation;

namespace TestServiceLayer;

[TestClass]
public class RoleServiceTest
{
    private RoleDto roleAdminDto;

    private RoleDto roleUserDto;

    private Role roleAdmin;

    private Role roleUser;

    private Mock<IRoleDataServices> roleDataServicesMock;

    private RoleServiceImpl roleDataServiceImpl;

    private Mock<ILogger<RoleServiceImpl>> logger;

    private Mock<RoleDtoValidator> validator;

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

        roleDataServicesMock = new Mock<IRoleDataServices>();
        logger = new Mock<ILogger<RoleServiceImpl>>();
        validator = new Mock<RoleDtoValidator>();

        roleDataServiceImpl = new RoleServiceImpl(roleDataServicesMock.Object, logger.Object, validator.Object);
    }

    [TestMethod]
    public void TestGetAllRoles()
    {
        roleDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Role> { roleAdmin, roleUser });

        var result = roleDataServiceImpl.GetAll();

        CollectionAssert.AreEquivalent(new List<RoleDto> { roleAdminDto, roleUserDto }, result.ToList());
    }
}