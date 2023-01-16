// <copyright file="OfferDtoValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto.Validator;

using FluentValidation;

/// <summary>
/// OfferDtoValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Dto.OfferDto&gt;" />
public class OfferDtoValidator : AbstractValidator<OfferDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfferDtoValidator"/> class.
    /// </summary>
    public OfferDtoValidator()
    {
        this.RuleFor(o => o.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(o => o.Price).GreaterThan(0);
        this.RuleFor(o => o.BidderId).GreaterThan(0);
        this.RuleFor(o => o.ProductId).GreaterThan(0);
        this.RuleFor(o => o.DateTime).GreaterThanOrEqualTo(DateTime.Now);
    }
}