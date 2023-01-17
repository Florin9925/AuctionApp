// <copyright file="OfferTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Entity;

using DomainModel.Entity;
using DomainModel.Entity.Validator;
using FluentValidation.TestHelper;

/// <summary>
/// OfferTest.
/// </summary>
[TestFixture]
public class OfferTest
{
    private OfferValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new OfferValidator();
    }

    /// <summary>
    /// Offers the identifier invalid.
    /// </summary>
    [Test]
    public void OfferIdInvalid()
    {
        var offer = new Offer
        {
            Id = -1,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Id);
    }

    /// <summary>
    /// Offers the identifier valid.
    /// </summary>
    [Test]
    public void OfferIdValid()
    {
        var offer = new Offer
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Id);
    }

    /// <summary>
    /// Offers the price invalid.
    /// </summary>
    [Test]
    public void OfferPriceInvalid()
    {
        var offer = new Offer
        {
            Price = 0,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Price);
    }

    /// <summary>
    /// Offers the price valid.
    /// </summary>
    [Test]
    public void OfferPriceValid()
    {
        var offer = new Offer
        {
            Price = 1,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Price);
    }

    /// <summary>
    /// Offers the date time is valid.
    /// </summary>
    [Test]
    public void OfferDateTimeIsValid()
    {
        var offer = new Offer
        {
            DateTime = DateTime.Now,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.DateTime);
    }

    /// <summary>
    /// Offers the date time is invalid.
    /// </summary>
    [Test]
    public void OfferDateTimeIsInvalid()
    {
        var offer = new Offer
        {
            DateTime = DateTime.Now.AddHours(-1),
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.DateTime);
    }

    /// <summary>
    /// Offers the bidder is null.
    /// </summary>
    [Test]
    public void OfferBidderIsNull()
    {
        var offer = new Offer
        {
            Bidder = null,
        };

        var result = this.validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Bidder);
    }

    /// <summary>
    /// Offers the bidder is not null.
    /// </summary>
    [Test]
    public void OfferBidderIsNotNull()
    {
        var offer = new Offer
        {
            Bidder = new User(),
        };

        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Bidder);
    }

    /// <summary>
    /// Offers the product is null.
    /// </summary>
    [Test]
    public void OfferProductIsNull()
    {
        var offer = new Offer
        {
            Product = null,
        };

        var result = this.validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.Product);
    }

    /// <summary>
    /// Offers the product is not null.
    /// </summary>
    [Test]
    public void OfferProductIsNotNull()
    {
        var offer = new Offer
        {
            Product = new Product(),
        };

        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Product);
    }
}