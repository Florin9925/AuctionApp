using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Dto;

[TestFixture]
public class OfferDtoTest
{
    private OfferDtoValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new OfferDtoValidator();
    }

    [Test]
    public void OfferIdInvalid()
    {
        var offer = new OfferDto
        {
            Id = -1
        };
        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    [Test]
    public void OfferIdValid()
    {
        var offer = new OfferDto
        {
            Id = 0
        };
        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Id);
    }

    [Test]
    public void OfferProductIdInvalid()
    {
        var offer = new OfferDto
        {
            ProductId = 0
        };
        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.ProductId);
    }

    [Test]
    public void OfferProductIdValid()
    {
        var offer = new OfferDto
        {
            ProductId = 1
        };
        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.ProductId);
    }

    [Test]
    public void OfferBidderIdInvalid()
    {
        var offer = new OfferDto
        {
            BidderId = 0
        };
        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.BidderId);
    }

    [Test]
    public void OfferBidderIdValid()
    {
        var offer = new OfferDto
        {
            BidderId = 1
        };
        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.BidderId);
    }

    [Test]
    public void OfferPriceInvalid()
    {
        var offer = new OfferDto
        {
            Price = 0
        };
        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Price);
    }

    [Test]
    public void OfferPriceValid()
    {
        var offer = new OfferDto
        {
            Price = 1
        };
        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Price);
    }

    [Test]
    public void OfferCtor()
    {
        var offer = new Offer
        {
            Id = 1,
            Price = 1,
            Bidder = new User
            {
                Id = 1
            },
            Product = new Product
            {
                Id = 1
            }
        };

        var offerDto = new OfferDto(offer);
        Assert.Multiple(() =>
        {
            Assert.That(offerDto.Id, Is.EqualTo(offer.Id));
            Assert.That(offerDto.Price, Is.EqualTo(offer.Price));
            Assert.That(offerDto.BidderId, Is.EqualTo(offer.Bidder.Id));
            Assert.That(offerDto.ProductId, Is.EqualTo(offer.Product.Id));
        });
    }
}