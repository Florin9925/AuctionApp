// <copyright file="OfferValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity.Validator;

using FluentValidation;

/// <summary>
/// OfferValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Entity.Offer&gt;" />
public class OfferValidator : AbstractValidator<Offer>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OfferValidator"/> class.
    /// </summary>
    public OfferValidator()
    {
        this.RuleFor(o => o.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(o => o.Price).GreaterThan(0);
        this.RuleFor(o => o.Bidder).NotNull();
        this.RuleFor(o => o.Product).NotNull();
        this.RuleFor(o => o.DateTime).GreaterThanOrEqualTo(DateTime.Now);
    }
}