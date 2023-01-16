// <copyright file="UserDtoValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto.Validator;

using FluentValidation;

/// <summary>
/// UserDtoValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Dto.UserDto&gt;" />
public class UserDtoValidator : AbstractValidator<UserDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserDtoValidator"/> class.
    /// </summary>
    public UserDtoValidator()
    {
        this.RuleFor(u => u.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(u => u.FirstName).NotEmpty().MinimumLength(2);
        this.RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
        this.RuleFor(u => u.Username).NotEmpty().MinimumLength(2);
        this.RuleFor(u => u.Email).NotNull().EmailAddress();
        this.RuleFor(u => u.Address).NotEmpty().MinimumLength(2);
        this.RuleFor(u => u.PhoneNumber)
            .NotEmpty()
            .NotNull().WithMessage("Phone Number is required.")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .Matches("^(\\+4|)?(07[0-9]{2}|02[0-9]{2}|03[0-9]{2}){1}?(\\s|\\.|\\-)?([0-9]{3}(\\s|\\.|\\-|)){2}$").WithMessage("PhoneNumber not valid");
    }
}