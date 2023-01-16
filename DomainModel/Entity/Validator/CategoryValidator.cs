// <copyright file="CategoryValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity.Validator;

using FluentValidation;

/// <summary>
/// CategoryValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Entity.Category&gt;" />
public class CategoryValidator : AbstractValidator<Category>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryValidator"/> class.
    /// </summary>
    public CategoryValidator()
    {
        this.RuleFor(c => c.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(c => c.Name).NotNull().Length(2, 50);
        this.RuleFor(c => c.Products).NotNull();
        this.RuleFor(c => c.ChildCategories).NotNull();
        this.RuleFor(c => c.ParentCategories).NotNull();
    }
}