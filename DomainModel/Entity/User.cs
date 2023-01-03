using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity;

public class User : BaseEntity
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string? LastName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string? Email { get; set; }

    public virtual IList<Product> Products { get; set; } = new List<Product>();
    public virtual IList<Role> Roles { get; set; } = new List<Role>();
    public virtual IList<Score> GetScores { get; set; } = new List<Score>();
    public virtual IList<Score> GivenScores { get; set; } = new List<Score>();
}

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(p => p.Id).NotNull();
        RuleFor(p => p.FirstName).NotEmpty();
        RuleFor(p => p.LastName).NotEmpty();
        RuleFor(p => p.Email).EmailAddress().NotEmpty();
    }
}