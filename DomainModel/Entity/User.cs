using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Email { get; set; }

        public virtual IList<Product>? Products { get; set; }
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
}
