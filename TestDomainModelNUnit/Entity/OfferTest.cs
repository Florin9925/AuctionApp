using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation.TestHelper;

namespace TestDomainModelNUnit.Entity;

[TestFixture]
public class OfferTest
{
    private OfferValidator _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new OfferValidator();
    }

    [Test]
    public void OfferIdInvalid()
    {
        var offer = new Offer
        {
            Id = -1
        };
        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    [Test]
    public void OfferIdValid()
    {
        var offer = new Offer
        {
            Id = 0
        };
        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Id);
    }

    [Test]
    public void OfferPriceInvalid()
    {
        var offer = new Offer
        {
            Price = 0
        };
        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Price);
    }

    [Test]
    public void OfferPriceValid()
    {
        var offer = new Offer
        {
            Price = 1
        };
        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Price);
    }

    [Test]
    public void OfferDateTimeIsValid()
    {
        var offer = new Offer
        {
            DateTime = DateTime.Now
        };
        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.DateTime);
    }

    [Test]
    public void OfferDateTimeIsInvalid()
    {
        var offer = new Offer
        {
            DateTime = DateTime.Now.AddHours(-1)
        };
        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.DateTime);
    }

    [Test]
    public void OfferBidderIsNull()
    {
        var offer = new Offer
        {
            Bidder = null
        };

        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Bidder);
    }

    [Test]
    public void OfferBidderIsNotNull()
    {
        var offer = new Offer
        {
            Bidder = new User()
        };

        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Bidder);
    }

    [Test]
    public void OfferProductIsNull()
    {
        var offer = new Offer
        {
            Product = null
        };

        var result = _validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Product);
    }

    [Test]
    public void OfferProductIsNotNull()
    {
        var offer = new Offer
        {
            Product = new Product()
        };

        var result = _validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Product);
    }
}