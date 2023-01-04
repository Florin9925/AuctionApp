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
        RuleFor(o => o.Id).NotNull();
    }
}