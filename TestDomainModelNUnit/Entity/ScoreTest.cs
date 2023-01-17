// <copyright file="ScoreTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Entity;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation.TestHelper;

/// <summary>
/// ScoreTest.
/// </summary>
[TestFixture]
public class ScoreTest
{
    private ScoreValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new ScoreValidator();
    }

    /// <summary>
    /// Scores the identifier invalid.
    /// </summary>
    [Test]
    public void ScoreIdInvalid()
    {
        var score = new Score
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Id);
    }

    /// <summary>
    /// Scores the identifier valid.
    /// </summary>
    [Test]
    public void ScoreIdValid()
    {
        var score = new Score
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Id);
    }

    /// <summary>
    /// Scores the value invalid.
    /// </summary>
    [Test]
    public void ScoreValueInvalid()
    {
        var score = new Score
        {
            Value = 0,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Value);
    }

    /// <summary>
    /// Scores the value valid.
    /// </summary>
    [Test]
    public void ScoreValueValid()
    {
        var score = new Score
        {
            Value = 1,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Value);
    }

    /// <summary>
    /// Scores the receiver identifier invalid.
    /// </summary>
    [Test]
    public void ScoreReceiverIdInvalid()
    {
        var score = new Score
        {
            ReceiverId = 0,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.ReceiverId);
    }

    /// <summary>
    /// Scores the receiver identifier valid.
    /// </summary>
    [Test]
    public void ScoreReceiverIdValid()
    {
        var score = new Score
        {
            ReceiverId = 1,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.ReceiverId);
    }

    /// <summary>
    /// Scores the reviewer identifier invalid.
    /// </summary>
    [Test]
    public void ScoreReviewerIdInvalid()
    {
        var score = new Score
        {
            ReviewerId = 0,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.ReviewerId);
    }

    /// <summary>
    /// Scores the reviewer identifier valid.
    /// </summary>
    [Test]
    public void ScoreReviewerIdValid()
    {
        var score = new Score
        {
            ReviewerId = 1,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.ReviewerId);
    }

    /// <summary>
    /// Scores the reviewer is null.
    /// </summary>
    [Test]
    public void ScoreReviewerIsNull()
    {
        var score = new Score
        {
            Reviewer = null,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Reviewer);
    }

    /// <summary>
    /// Scores the reviewer is not null.
    /// </summary>
    [Test]
    public void ScoreReviewerIsNotNull()
    {
        var score = new Score
        {
            Reviewer = new User()
            {
                Id = 1,
            },
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Reviewer);
    }

    /// <summary>
    /// Scores the receiver is null.
    /// </summary>
    [Test]
    public void ScoreReceiverIsNull()
    {
        var score = new Score
        {
            Receiver = null,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Receiver);
    }

    /// <summary>
    /// Scores the receiver is not null.
    /// </summary>
    [Test]
    public void ScoreReceiverIsNotNull()
    {
        var score = new Score
        {
            Receiver = new User()
            {
                Id = 1,
            },
        };
        var result = validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Receiver);
    }
}