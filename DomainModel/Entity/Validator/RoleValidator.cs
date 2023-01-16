// <copyright file="RoleValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity.Validator;

using FluentValidation;

/// <summary>
/// RoleValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Entity.Role&gt;" />
public class RoleValidator : AbstractValidator<Role>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleValidator"/> class.
    /// </summary>
    public RoleValidator()
    {
        this.RuleFor(r => r.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(r => r.Name).MinimumLength(2);
        this.RuleFor(r => r.Name).NotNull();
        this.RuleFor(r => r.Users).NotNull();
    }
}