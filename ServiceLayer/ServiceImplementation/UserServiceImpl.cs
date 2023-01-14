using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ServiceLayer.Exception;

namespace ServiceLayer.ServiceImplementation;

public class UserServiceImpl : IUserService
{
    private readonly IUserDataServices _userAccountDataServices;
    private readonly ILogger<UserServiceImpl> _logger;
    private readonly UserDtoValidator _validator;

    public UserServiceImpl(
        IUserDataServices userAccountDataServices,
        ILogger<UserServiceImpl> logger,
        UserDtoValidator validator)
    {
        _userAccountDataServices = userAccountDataServices;
        _logger = logger;
        _validator = validator;
    }

    void ICRUDService<UserDto>.DeleteById(int id)
    {
        _logger.LogInformation("Delete user with id {0}", id);

        var user = _userAccountDataServices.GetById(id);
        if (user == null)
        {
            throw new NotFoundException<UserDto>(id, _logger);
        }

        _userAccountDataServices.Delete(user);
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
        if (user == null)
        {
            throw new NotFoundException<UserDto>(id, _logger);
        }

        return new UserDto(user);
    }

    UserDto ICRUDService<UserDto>.Insert(UserDto dto)
    {
        _logger.LogInformation("Insert user {0}", dto);
        _validator.ValidateAndThrow(dto);

        var user = new User
        {
            Id = 0,
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
            throw new NotFoundException<UserDto>(dto, _logger);
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