using DataMapper;
using DomainModel.DTO;
using Microsoft.Extensions.Logging;

namespace ServiceLayer.ServiceImplementation;

public class UserServiceImpl : IUserService
{
    private readonly IUserDataServices _userAccountDataServices;
    private readonly ILogger _logger;

    public UserServiceImpl(IUserDataServices userAccountDataServices, ILogger<UserServiceImpl> logger)
    {
        _userAccountDataServices = userAccountDataServices;
        _logger = logger;
    }

    void ICRUDService<UserDto>.Delete(UserDto dto)
    {
        throw new NotImplementedException();
    }

    IList<UserDto> ICRUDService<UserDto>.GetAll()
    {
        _logger.LogInformation("Get all users");
        var users = _userAccountDataServices.GetAll();

        return users.Select(user => new UserDto(user)).ToList();
    }

    UserDto ICRUDService<UserDto>.GetById(int id)
    {
        var user = _userAccountDataServices.GetById(id);
        return new UserDto(user);
    }

    UserDto ICRUDService<UserDto>.Insert(UserDto dto)
    {
        throw new NotImplementedException();
    }

    UserDto ICRUDService<UserDto>.Update(UserDto dto)
    {
        throw new NotImplementedException();
    }
}