using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer.Exception;

namespace ServiceLayer.ServiceImplementation;

public class UserServiceImpl : IUserService
{
    private readonly IUserDataServices _userAccountDataServices;
    private readonly ILogger _logger;
    private readonly UserDtoValidator _validator;

    public UserServiceImpl(
        IUserDataServices userAccountDataServices,
        ILogger logger,
        UserDtoValidator validator)
    {
        _userAccountDataServices = userAccountDataServices;
        _logger = logger;
        _validator = validator;
    }

    void ICRUDService<UserDto>.Delete(UserDto dto)
    {
        _logger.LogInformation("Delete user with id {0}", dto.Id);
        _userAccountDataServices.Delete(_userAccountDataServices.GetById(dto.Id));
    }

    IList<UserDto> ICRUDService<UserDto>.GetAll()
    {
        _logger.LogInformation("Get all users");
        var users = _userAccountDataServices.GetAll();

        return users.Select(user => new UserDto(user)).ToList();
    }

    UserDto ICRUDService<UserDto>.GetById(int id)
    {
        _logger.LogInformation("Get user with id {0}", id);
        var user = _userAccountDataServices.GetById(id);
        return new UserDto(user);
    }

    UserDto ICRUDService<UserDto>.Insert(UserDto dto)
    {
        _logger.LogInformation("Insert user {0}", dto);
        _validator.ValidateAndThrow(dto);

        var user = new User
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Username = dto.Username,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber
        };

        return new UserDto(_userAccountDataServices.Insert(user));
    }

    UserDto ICRUDService<UserDto>.Update(UserDto dto)
    {
        _logger.LogInformation("Update user {0}", dto);
        _validator.ValidateAndThrow(dto);

        var user = _userAccountDataServices.GetById(dto.Id);
        if (user == null)
        {
            throw new InvalidUserExeption(dto);
        }

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.Username = dto.Username;
        user.Address = dto.Address;
        user.PhoneNumber = dto.PhoneNumber;

        return new UserDto(_userAccountDataServices.Update(user));
    }
}