using DataMapper;
using DomainModel.DTO;

namespace ServiceLayer.ServiceImplementation;

public class UserServiceImpl : IUserService
{
    private readonly IUserDataServices _userAccountDataServices;

    public UserServiceImpl(IUserDataServices userAccountDataServices)
    {
        _userAccountDataServices = userAccountDataServices;
    }

    void ICRUDService<UserDto>.Delete(UserDto dto)
    {
        throw new NotImplementedException();
    }

    IList<UserDto> ICRUDService<UserDto>.GetAll()
    {
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