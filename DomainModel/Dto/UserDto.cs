using System.Text.RegularExpressions;
using DomainModel.Entity;
using FluentValidation;

namespace DomainModel.Dto;

public class UserDto : BaseDto
{
    public UserDto()
    {
    }

    public UserDto(User user)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        Address = user.Address;
        PhoneNumber = user.PhoneNumber;
        Username = user.Username;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Username { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public override bool Equals(object? obj)
    {
        return obj is UserDto dto &&
               Id == dto.Id &&
               FirstName == dto.FirstName &&
               LastName == dto.LastName &&
               Email == dto.Email &&
               Address == dto.Address &&
               PhoneNumber == dto.PhoneNumber &&
               Username == dto.Username;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FirstName, LastName, Email, Address, PhoneNumber, Username);
    }
}

public partial class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(u => u.Id).GreaterThanOrEqualTo(0);
        RuleFor(u => u.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
        RuleFor(u => u.Username).NotEmpty().MinimumLength(2);
        RuleFor(u => u.Email).NotNull().EmailAddress();
        RuleFor(u => u.Address).NotEmpty().MinimumLength(2);
        RuleFor(u => u.PhoneNumber)
            .NotEmpty()
            .NotNull().WithMessage("Phone Number is required.")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .Matches(MyRegex()).WithMessage("PhoneNumber not valid");
    }

    [GeneratedRegex("^(\\+4|)?(07[0-9]{2}|02[0-9]{2}|03[0-9]{2}){1}?(\\s|\\.|\\-)?([0-9]{3}(\\s|\\.|\\-|)){2}$")]
    private static partial Regex MyRegex();
}