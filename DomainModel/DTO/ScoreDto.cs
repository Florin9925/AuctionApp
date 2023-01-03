using DomainModel.Entity;

namespace DomainModel.DTO;

public class ScoreDto : BaseDto
{
    public int ReviewerId { get; set; }
    public int ReceiverId { get; set; }
    public int Value { get; set; }

    public ScoreDto(Score score)
    {
        Id = score.Id;
        ReviewerId = score.Reviewer.Id;
        ReceiverId = score.Receiver.Id;
        Value = score.Value;
    }
}