// <copyright file="ScoreValidator.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DomainModel.Entity.Validator;

using FluentValidation;

/// <summary>
/// ScoreValidator.
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;DomainModel.Entity.Score&gt;" />
public class ScoreValidator : AbstractValidator<Score>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScoreValidator"/> class.
    /// </summary>
    public ScoreValidator()
    {
        this.RuleFor(s => s.Id).GreaterThanOrEqualTo(0);
        this.RuleFor(s => s.Value).GreaterThan(0);
        this.RuleFor(s => s.ReviewerId).GreaterThan(0);
        this.RuleFor(s => s.ReceiverId).GreaterThan(0);
        this.RuleFor(s => s.Reviewer).NotNull();
        this.RuleFor(s => s.Receiver).NotNull();
    }
}