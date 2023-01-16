// <copyright file="RoleDtoValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto.Validator;

using FluentValidation;

/// <summary>
/// RoleDtoValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Dto.RoleDto&gt;" />
public class RoleDtoValidator : AbstractValidator<RoleDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleDtoValidator"/> class.
    /// </summary>
    public RoleDtoValidator()
    {
        this.RuleFor(r => r.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(r => r.Name).MinimumLength(2);
        this.RuleFor(r => r.Name).NotNull();
    }
}