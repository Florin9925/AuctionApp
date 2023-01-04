using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DomainModel.Entity;

public class Role : BaseEntity
{
    [Required]
    [StringLength(500, MinimumLength = 2)]
    public string Name { get; set; }
}

public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(r => r.Id).NotNull();
    }
}