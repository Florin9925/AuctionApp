using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Dto;

[TestFixture]
public class ScoreDtoTest
{
    private ScoreDtoValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new ScoreDtoValidator();
    }

    [Test]
    public void ScoreDtoIdInvalid()
    {
        var score = new ScoreDto
        {
            Id = -1
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Id);
    }

    [Test]
    public void ScoreDtoIdValid()
    {
        var score = new ScoreDto
        {
            Id = 0
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Id);
    }

    [Test]
    public void ScoreDtoValueInvalid()
    {
        var score = new ScoreDto
        {
            Value = 0
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Value);
    }

    [Test]
    public void ScoreDtoValueValid()
    {
        var score = new ScoreDto
        {
            Value = 1
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Value);
    }

    [Test]
    public void ScoreDtoReceiverIdInvalid()
    {
        var score = new ScoreDto
        {
            ReceiverId = 0
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.ReceiverId);
    }

    [Test]
    public void ScoreDtoReceiverIdValid()
    {
        var score = new ScoreDto
        {
            ReceiverId = 1
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.ReceiverId);
    }

    [Test]
    public void ScoreDtoReviewerIdInvalid()
    {
        var score = new ScoreDto
        {
            ReviewerId = 0
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.ReviewerId);
    }

    [Test]
    public void ScoreDtoReviewerIdValid()
    {
        var score = new ScoreDto
        {
            ReviewerId = 1
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.ReviewerId);
    }

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
                Id = 1
            },
            Receiver = new User
            {
                Id = 1
            }
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