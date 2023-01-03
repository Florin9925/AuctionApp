using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity;

public class Role : BaseEntity
{
    [Required]
    [StringLength(500, MinimumLength = 2)]
    public string? Name { get; set; }
}