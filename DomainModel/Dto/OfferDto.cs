using DomainModel.Entity;
using FluentValidation;

namespace DomainModel.Dto;

public class OfferDto : BaseDto
{
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int BidderId { get; set; }
    public DateTime DateTime { get; set; }

    public OfferDto()
    {
    }

    public OfferDto(Offer offer)
    {
        Id = offer.Id;
        ProductId = offer.Product.Id;
        Price = offer.Price;
        BidderId = offer.Bidder.Id;
        DateTime = offer.DateTime;
    }

    public override string ToString()
    {
        return $"OfferDto: Id={Id}, ProductId={ProductId}, Price={Price}, BidderId={BidderId}, DateTime={DateTime}";
    }

    public override bool Equals(object obj)
    {
        return obj is OfferDto dto &&
               Id == dto.Id &&
               ProductId == dto.ProductId &&
               Price == dto.Price &&
               BidderId == dto.BidderId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, ProductId, Price, BidderId, DateTime);
    }
}

public class OfferDtoValidator : AbstractValidator<OfferDto>
{
    public OfferDtoValidator()
    {
        RuleFor(o => o.Id).GreaterThanOrEqualTo(0);
        RuleFor(o => o.Price).GreaterThan(0);
        RuleFor(o => o.BidderId).GreaterThan(0);
        RuleFor(o => o.ProductId).GreaterThan(0);
        RuleFor(o => o.DateTime).GreaterThanOrEqualTo(DateTime.Now);
    }
}