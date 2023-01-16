﻿// <copyright file="ProductDtoValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto.Validator;

using FluentValidation;

/// <summary>
/// ProductDtoValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Dto.ProductDto&gt;" />
public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDtoValidator"/> class.
    /// </summary>
    public ProductDtoValidator()
    {
        this.RuleFor(p => p.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(p => p.Name).NotEmpty();
        this.RuleFor(p => p.Description).NotEmpty();
        this.RuleFor(p => p.Description).MinimumLength(2);
        this.RuleFor(p => p.StartDate).LessThan(p => p.EndDate).WithMessage("Start date must be before end date");
        this.RuleFor(p => p.StartDate).GreaterThan(DateTime.Now).WithMessage("Start date must be in the future");
        this.RuleFor(p => p.OwnerId).GreaterThan(0);
        this.RuleFor(p => p.Currency).IsInEnum();
        this.RuleFor(p => p.Amount).GreaterThan(0);
        this.RuleFor(p => p.CategoryId).GreaterThan(0);
        this.RuleFor(p => p.InitialPrice).GreaterThanOrEqualTo(0);
    }
}