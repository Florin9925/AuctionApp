// <copyright file="ScoreDtoValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Dto.Validator;

using FluentValidation;

/// <summary>
/// ScoreDtoValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Dto.ScoreDto&gt;" />
public class ScoreDtoValidator : AbstractValidator<ScoreDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScoreDtoValidator"/> class.
    /// </summary>
    public ScoreDtoValidator()
    {
        this.RuleFor(s => s.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(s => s.Value).GreaterThan(0);
        this.RuleFor(s => s.ReviewerId).GreaterThan(0);
        this.RuleFor(s => s.ReceiverId).GreaterThan(0);
    }
}