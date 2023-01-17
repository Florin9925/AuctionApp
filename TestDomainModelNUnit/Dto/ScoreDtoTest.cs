// <copyright file="ScoreDtoTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Dto;

using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation.TestHelper;

/// <summary>
/// ScoreDtoTest.
/// </summary>
[TestFixture]
public class ScoreDtoTest
{
    private ScoreDtoValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new ScoreDtoValidator();
    }

    /// <summary>
    /// Scores the dto identifier invalid.
    /// </summary>
    [Test]
    public void ScoreDtoIdInvalid()
    {
        var score = new ScoreDto
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Id);
    }

    /// <summary>
    /// Scores the dto identifier valid.
    /// </summary>
    [Test]
    public void ScoreDtoIdValid()
    {
        var score = new ScoreDto
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Id);
    }

    /// <summary>
    /// Scores the dto value invalid.
    /// </summary>
    [Test]
    public void ScoreDtoValueInvalid()
    {
        var score = new ScoreDto
        {
            Value = 0,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Value);
    }

    /// <summary>
    /// Scores the dto value valid.
    /// </summary>
    [Test]
    public void ScoreDtoValueValid()
    {
        var score = new ScoreDto
        {
            Value = 1,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Value);
    }

    /// <summary>
    /// Scores the dto receiver identifier invalid.
    /// </summary>
    [Test]
    public void ScoreDtoReceiverIdInvalid()
    {
        var score = new ScoreDto
        {
            ReceiverId = 0,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.ReceiverId);
    }

    /// <summary>
    /// Scores the dto receiver identifier valid.
    /// </summary>
    [Test]
    public void ScoreDtoReceiverIdValid()
    {
        var score = new ScoreDto
        {
            ReceiverId = 1,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.ReceiverId);
    }

    /// <summary>
    /// Scores the dto reviewer identifier invalid.
    /// </summary>
    [Test]
    public void ScoreDtoReviewerIdInvalid()
    {
        var score = new ScoreDto
        {
            ReviewerId = 0,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.ReviewerId);
    }

    /// <summary>
    /// Scores the dto reviewer identifier valid.
    /// </summary>
    [Test]
    public void ScoreDtoReviewerIdValid()
    {
        var score = new ScoreDto
        {
            ReviewerId = 1,
        };
        var result = this.validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.ReviewerId);
    }

    /// <summary>
    /// Scores the dto ctor.
    /// </summary>
    [Test]
    public void ScoreDtoCtor()
    {
        var score = new Score
        {
            Id = 1,
            Value = 1,
            ReceiverId = 1,
            ReviewerId = 1,
            Reviewer = new User
            {
                Id = 1,
            },
            Receiver = new User
            {
                Id = 1,
            },
        };

        var scoreDto = new ScoreDto(score);
        Assert.Multiple(() =>
        {
            Assert.That(scoreDto.Id, Is.EqualTo(score.Id));
            Assert.That(scoreDto.Value, Is.EqualTo(score.Value));
            Assert.That(scoreDto.ReceiverId, Is.EqualTo(score.ReceiverId));
            Assert.That(scoreDto.ReviewerId, Is.EqualTo(score.ReviewerId));
        });
    }
}