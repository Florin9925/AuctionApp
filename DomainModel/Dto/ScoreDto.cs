using DomainModel.Entity;
using FluentValidation;

namespace DomainModel.Dto;

public class ScoreDto : BaseDto
{
    public int ReviewerId { get; set; }
    public int ReceiverId { get; set; }
    public int Value { get; set; }

    public ScoreDto()
    {
    }

    public ScoreDto(Score score)
    {
        Id = score.Id;
        ReviewerId = score.Reviewer.Id;
        ReceiverId = score.Receiver.Id;
        Value = score.Value;
    }
}

public class ScoreDtoValidator : AbstractValidator<ScoreDto>
{
    public ScoreDtoValidator()
    {
        RuleFor(s => s.Id).GreaterThanOrEqualTo(0);
        RuleFor(s => s.Value).GreaterThan(0);
        RuleFor(s => s.ReviewerId).GreaterThan(0);
        RuleFor(s => s.ReceiverId).GreaterThan(0);
    }
}