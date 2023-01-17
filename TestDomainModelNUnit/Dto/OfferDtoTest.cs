// <copyright file="OfferDtoTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestDomainModelNUnit.Dto;

using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using FluentValidation.TestHelper;

/// <summary>
/// OfferDtoTest.
/// </summary>
[TestFixture]
public class OfferDtoTest
{
    private OfferDtoValidator validator;

    /// <summary>
    /// Sets up.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.validator = new OfferDtoValidator();
    }

    /// <summary>
    /// Offers the identifier invalid.
    /// </summary>
    [Test]
    public void OfferIdInvalid()
    {
        var offer = new OfferDto
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
        var offer = new OfferDto
        {
            Id = 0,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Id);
    }

    /// <summary>
    /// Offers the product identifier invalid.
    /// </summary>
    [Test]
    public void OfferProductIdInvalid()
    {
        var offer = new OfferDto
        {
            ProductId = 0,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.ProductId);
    }

    /// <summary>
    /// Offers the product identifier valid.
    /// </summary>
    [Test]
    public void OfferProductIdValid()
    {
        var offer = new OfferDto
        {
            ProductId = 1,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.ProductId);
    }

    /// <summary>
    /// Offers the bidder identifier invalid.
    /// </summary>
    [Test]
    public void OfferBidderIdInvalid()
    {
        var offer = new OfferDto
        {
            BidderId = 0,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldHaveValidationErrorFor(p => p.BidderId);
    }

    /// <summary>
    /// Offers the bidder identifier valid.
    /// </summary>
    [Test]
    public void OfferBidderIdValid()
    {
        var offer = new OfferDto
        {
            BidderId = 1,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.BidderId);
    }

    /// <summary>
    /// Offers the price invalid.
    /// </summary>
    [Test]
    public void OfferPriceInvalid()
    {
        var offer = new OfferDto
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
        var offer = new OfferDto
        {
            Price = 1,
        };
        var result = this.validator.TestValidate(offer);
        result.ShouldNotHaveValidationErrorFor(p => p.Price);
    }

    /// <summary>
    /// Offers the ctor.
    /// </summary>
    [Test]
    public void OfferCtor()
    {
        var offer = new Offer
        {
            Id = 1,
            Price = 1,
            Bidder = new User
            {
                Id = 1,
            },
            Product = new Product
            {
                Id = 1,
            },
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