using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DomainModel.Entity;

public class Offer : BaseEntity
{
    [Required] public Product Product { get; set; }

    [Required] public decimal Price { get; set; }

    [Required] public User Bidder { get; set; }

    [Required] public DateTime DateTime { get; set; }
}

public class OfferValidator : AbstractValidator<Offer>
{
    public OfferValidator()
    {
        RuleFor(o => o.Id).GreaterThanOrEqualTo(0);
        RuleFor(o => o.Price).GreaterThan(0);
        RuleFor(o => o.Bidder).NotNull();
        RuleFor(o => o.Product).NotNull();
        RuleFor(o => o.DateTime).GreaterThanOrEqualTo(DateTime.Now);
    }
}