using DomainModel.Entity;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Entity;

[TestFixture]
public class ScoreTest
{
    private ScoreValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new ScoreValidator();
    }

    [Test]
    public void ScoreIdInvalid()
    {
        var score = new Score
        {
            Id = -1
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Id);
    }

    [Test]
    public void ScoreIdValid()
    {
        var score = new Score
        {
            Id = 0
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Id);
    }

    [Test]
    public void ScoreValueInvalid()
    {
        var score = new Score
        {
            Value = 0
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Value);
    }

    [Test]
    public void ScoreValueValid()
    {
        var score = new Score
        {
            Value = 1
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Value);
    }

    [Test]
    public void ScoreReceiverIdInvalid()
    {
        var score = new Score
        {
            ReceiverId = 0
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.ReceiverId);
    }

    [Test]
    public void ScoreReceiverIdValid()
    {
        var score = new Score
        {
            ReceiverId = 1
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.ReceiverId);
    }

    [Test]
    public void ScoreReviewerIdInvalid()
    {
        var score = new Score
        {
            ReviewerId = 0
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.ReviewerId);
    }

    [Test]
    public void ScoreReviewerIdValid()
    {
        var score = new Score
        {
            ReviewerId = 1
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.ReviewerId);
    }

    [Test]
    public void ScoreReviewerIsNull()
    {
        var score = new Score
        {
            Reviewer = null
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Reviewer);
    }

    [Test]
    public void ScoreReviewerIsNotNull()
    {
        var score = new Score
        {
            Reviewer = new User()
            {
                Id = 1
            }
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Reviewer);
    }

    [Test]
    public void ScoreReceiverIsNull()
    {
        var score = new Score
        {
            Receiver = null
        };
        var result = _validator.TestValidate(score);
        result.ShouldHaveValidationErrorFor(s => s.Receiver);
    }

    [Test]
    public void ScoreReceiverIsNotNull()
    {
        var score = new Score
        {
            Receiver = new User()
            {
                Id = 1
            }
        };
        var result = _validator.TestValidate(score);
        result.ShouldNotHaveValidationErrorFor(s => s.Receiver);
    }
}