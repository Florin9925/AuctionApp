// <copyright file="CategoryDtoValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto.Validator;

using DomainModel.Entity;
using FluentValidation;

/// <summary>
/// CategoryDtoValidator.
/// </summary>
/// <seealso cref="AbstractValidator&lt;CategoryDto&gt;" />
public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryDtoValidator"/> class.
    /// </summary>
    public CategoryDtoValidator()
    {
        this.RuleFor(c => c.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(c => c.Name).NotNull().Length(2, 50);
        this.RuleFor(c => c.ChildCategoryIds).NotNull();
        this.RuleFor(c => c.ParentCategoryIds).NotNull();
    }
}