using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DomainModel.Entity;

public class Role : BaseEntity
{
    [Required]
    [StringLength(500, MinimumLength = 2)]
    public string Name { get; set; }

    public IList<User> Users { get; set; }
}

public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(r => r.Id).GreaterThanOrEqualTo(0);
        RuleFor(r => r.Name).MinimumLength(2);
        RuleFor(r => r.Name).NotNull();
        RuleFor(r => r.Users).NotNull();
    }
}