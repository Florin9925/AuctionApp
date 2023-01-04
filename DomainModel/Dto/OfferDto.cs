using DomainModel.Entity;
using FluentValidation;

namespace DomainModel.Dto;

public class OfferDto : BaseDto
{
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int BidderId { get; set; }
    public DateTime DateTime { get; set; }

    public OfferDto(Offer offer)
    {
        Id = offer.Id;
        ProductId = offer.Product.Id;
        Price = offer.Price;
        BidderId = offer.Bidder.Id;
        DateTime = offer.DateTime;
    }
}

public class OfferDtoValidator : AbstractValidator<OfferDto>
{
    public OfferDtoValidator()
    {
        RuleFor(o => o.Id).NotNull();
    }
}