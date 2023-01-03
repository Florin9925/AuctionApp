using DataMapper;
using DomainModel.Configuration;
using DomainModel.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ServiceLayer.ServiceImplementation;

public class UserServiceImpl : IUserService
{
    private readonly IUserDataServices _userAccountDataServices;
    private readonly ILogger _logger;
    private readonly MyConfiguration _myConfiguation;

    public UserServiceImpl(IUserDataServices userAccountDataServices, ILogger<UserServiceImpl> logger,
        IOptions<MyConfiguration> myConfiguration)
    {
        _userAccountDataServices = userAccountDataServices;
        _logger = logger;
        _myConfiguation = myConfiguration.Value;
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