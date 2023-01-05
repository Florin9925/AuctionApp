using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DomainModel.Entity;

public class User : BaseEntity
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string LastName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Username { get; set; }

    [Required] public string PhoneNumber { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Address { get; set; }

    public virtual IList<Product> Products { get; set; } = new List<Product>();
    public virtual IList<Role> Roles { get; set; } = new List<Role>();
    public virtual IList<Score> GetScores { get; set; } = new List<Score>();
    public virtual IList<Score> GivenScores { get; set; } = new List<Score>();
}

public partial class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Id).GreaterThanOrEqualTo(0);
        RuleFor(u => u.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
        RuleFor(u => u.Username).NotEmpty().MinimumLength(2);
        RuleFor(u => u.Email).NotNull().EmailAddress();
        RuleFor(u => u.Address).NotEmpty().MinimumLength(2);
        RuleFor(u => u.PhoneNumber)
            .NotEmpty()
            .NotNull().WithMessage("Phone Number is required.")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .Matches(MyRegex()).WithMessage("PhoneNumber not valid");
    }

    [GeneratedRegex("^(\\+4|)?(07[0-9]{2}|02[0-9]{2}|03[0-9]{2}){1}?(\\s|\\.|\\-)?([0-9]{3}(\\s|\\.|\\-|)){2}$")]
    private static partial Regex MyRegex();
}