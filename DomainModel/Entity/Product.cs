using DomainModel.Enum;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity;

public class Product : BaseEntity
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [StringLength(500, MinimumLength = 2)]
    public string Description { get; set; }

    [Required] public DateTime StartDate { get; set; }

    [Required] public DateTime EndDate { get; set; }

    [Required] public User Owner { get; set; }

    [Required] public int Amount { get; set; } = 1;
    [Required] public decimal InitialPrice { get; set; } = 0;

    [Required] public Currency Currency { get; set; }

    [Required] public Category Category { get; set; }

    public virtual IList<Offer> Offers { get; set; } = new List<Offer>();
}

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Id).GreaterThanOrEqualTo(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.Description).MinimumLength(2);
        RuleFor(p => p.StartDate).LessThan(p => p.EndDate).WithMessage("Start date must be before end date");
        RuleFor(p => p.StartDate).GreaterThan(DateTime.Now).WithMessage("Start date must be in the future");
        RuleFor(p => p.Owner).NotNull();
        RuleFor(p => p.Category).NotNull();
        RuleFor(p => p.Currency).IsInEnum();
        RuleFor(p => p.Amount).GreaterThan(0);
        RuleFor(p => p.InitialPrice).GreaterThanOrEqualTo(0);
        RuleFor(p => p.Offers).NotNull();
    }
}