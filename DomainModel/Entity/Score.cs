using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity;

public class Score : BaseEntity
{
    [Required] public User Reviewer { get; set; }

    public int ReviewerId { get; set; }

    [Required] public User Receiver { get; set; }
    public int ReceiverId { get; set; }
    
    [Required] public int Value { get; set; }
}