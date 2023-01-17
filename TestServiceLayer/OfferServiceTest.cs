// <copyright file="OfferServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestServiceLayer;

using DataMapper;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

/// <summary>
/// OfferServiceTest.
/// </summary>
[TestClass]
public class OfferServiceTest
{
    private OfferDto offerDto;
    private OfferDto lastOfferDto;

    private OfferDto nullOfferDto = null;
    private OfferDto notFoundOfferDto;
    private OfferDto invalidOfferDto;

    private Offer offer;

    private Offer lastOffer;

    private Offer nullOffer = null;

    private IOfferService offerService;

    private Mock<IOfferDataServices> offerDataServicesMock;

    private Mock<IProductDataServices> productServiceMock;

    private Mock<IUserDataServices> userDataServicesMock;

    private Mock<ILogger<OfferServiceImpl>> loggerMock;

    /// <summary>
    /// Tests the initialize.
    /// </summary>
    [TestInitialize]
    public void TestInitialize()
    {
        var product = new Product
        {
            Id = 1,
            InitialPrice = 100,
            StartDate = DateTime.Now.AddDays(1),
            EndDate = DateTime.Now.AddDays(2),
            Category = new Category { Id = 1 },
            Owner = new User { Id = 1 },
        };

        this.offer = new Offer
        {
            Id = 2,
            Product = product,
            Bidder = new User { Id = 2 },
            Price = 200,
            DateTime = DateTime.Now.AddMinutes(1),
        };

        this.lastOffer = new Offer
        {
            Id = 1,
            Product = product,
            Bidder = new User { Id = 2 },
            Price = 150,
        };

        this.notFoundOfferDto = new OfferDto
        {
            Id = int.MaxValue,
            ProductId = int.MaxValue,
            BidderId = int.MaxValue,
            Price = 200,
        };

        this.invalidOfferDto = new OfferDto
        {
            Id = 1,
            ProductId = 1,
            BidderId = 1,
            Price = int.MaxValue,
            DateTime = DateTime.Now.AddMinutes(1),
        };

        this.offerDataServicesMock = new Mock<IOfferDataServices>();
        this.productServiceMock = new Mock<IProductDataServices>();
        this.userDataServicesMock = new Mock<IUserDataServices>();
        this.loggerMock = new Mock<ILogger<OfferServiceImpl>>();

        this.offerDto = new OfferDto(this.offer);
        this.lastOfferDto = new OfferDto(this.lastOffer);

        this.offerService = new OfferServiceImpl(
            this.offerDataServicesMock.Object,
            this.productServiceMock.Object,
            this.userDataServicesMock.Object,
            this.loggerMock.Object,
            new OfferDtoValidator());
    }

    /// <summary>
    /// Tests the offer get all.
    /// </summary>
    [TestMethod]
    public void TestOfferGetAll()
    {
        this.offerDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Offer> { this.offer, this.lastOffer });

        var result = this.offerService.GetAll();

        CollectionAssert.AreEquivalent(new List<OfferDto> { this.offerDto, this.lastOfferDto }, result.ToList());
    }

    /// <summary>
    /// Tests the offer get all product offers.
    /// </summary>
    [TestMethod]
    public void TestOfferGetAllProductOffers()
    {
        this.offerDataServicesMock.Setup(x => x.GetAllProductOffers(this.offerDto.ProductId))
            .Returns(new List<Offer> { this.offer, this.lastOffer });

        var result = this.offerService.GetAllProductOffers(this.offerDto.ProductId);

        CollectionAssert.AreEquivalent(new List<OfferDto> { this.offerDto, this.lastOfferDto }, result.ToList());
    }

    /// <summary>
    /// Tests the offer get by identifier.
    /// </summary>
    [TestMethod]
    public void TestOfferGetById()
    {
        this.offerDataServicesMock.Setup(x => x.GetById(this.offer.Id)).Returns(this.offer);

        var result = this.offerService.GetById(this.offer.Id);

        Assert.AreEqual(this.offerDto, result);
    }

    /// <summary>
    /// Tests the offer get by identifier not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<OfferDto>))]
    public void TestOfferGetByIdNotFound()
    {
        this.offerDataServicesMock.Setup(x => x.GetById(this.notFoundOfferDto)).Returns(this.nullOffer);
        this.offerService.GetById(this.offer.Id);
    }

    /// <summary>
    /// Tests the offer get last offer.
    /// </summary>
    [TestMethod]
    public void TestOfferGetLastOffer()
    {
        this.offerDataServicesMock.Setup(x => x.GetLastProductOffer(this.offerDto.ProductId)).Returns(this.lastOffer);
        this.productServiceMock.Setup(x => x.GetById(this.offerDto.ProductId)).Returns(this.offer.Product);

        var result = this.offerService.GetLastProductOffer(this.offerDto.ProductId);

        Assert.AreEqual(this.lastOfferDto, result);
    }

    /// <summary>
    /// Tests the offer get last offer not exist.
    /// </summary>
    [TestMethod]
    public void TestOfferGetLastOfferNotExist()
    {
        this.offerDataServicesMock.Setup(x => x.GetLastProductOffer(this.offerDto.ProductId)).Returns(this.nullOffer);
        this.productServiceMock.Setup(x => x.GetById(this.offerDto.ProductId)).Returns(this.offer.Product);

        var result = this.offerService.GetLastProductOffer(this.offerDto.ProductId);

        Assert.AreEqual(null, result);
    }

    /// <summary>
    /// Tests the offer get last offer bot found product.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestOfferGetLastOfferBotFoundProduct()
    {
        this.offerDataServicesMock.Setup(x => x.GetLastProductOffer(this.offerDto.ProductId)).Returns(this.nullOffer);
        this.offerService.GetLastProductOffer(this.offerDto.ProductId);
    }

    /// <summary>
    /// Tests the offer create.
    /// </summary>
    [TestMethod]
    public void TestOfferCreate()
    {
        this.offerDataServicesMock.Setup(x => x.Insert(It.IsAny<Offer>())).Returns(this.offer);
        this.productServiceMock.Setup(x => x.GetById(this.offerDto.ProductId)).Returns(this.offer.Product);
        this.userDataServicesMock.Setup(x => x.GetById(this.offerDto.BidderId)).Returns(this.offer.Bidder);

        var result = this.offerService.Insert(this.offerDto);

        Assert.AreEqual(this.offerDto, result);
    }

    /// <summary>
    /// Tests the offer create invalid offer.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidDataException<OfferDto>))]
    public void TestOfferCreateInvalidOffer()
    {
        this.productServiceMock.Setup(x => x.GetById(this.offerDto.ProductId)).Returns(this.offer.Product);
        this.userDataServicesMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(this.offer.Bidder);
        this.offerDataServicesMock.Setup(x => x.GetLastProductOffer(It.IsAny<int>())).Returns(this.lastOffer);

        this.offerService.Insert(this.invalidOfferDto);
    }

    /// <summary>
    /// Tests the offer create invalid offer2.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidDataException<OfferDto>))]
    public void TestOfferCreateInvalidOffer2()
    {
        this.offerDataServicesMock.Setup(x => x.GetLastProductOffer(this.offerDto.ProductId)).Returns(this.nullOffer);
        this.productServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(this.offer.Product);
        this.userDataServicesMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(this.offer.Bidder);

        this.offerService.Insert(this.invalidOfferDto);
    }

    /// <summary>
    /// Tests the offer create not found product.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestOfferCreateNotFoundProduct()
    {
        this.productServiceMock.Setup(x => x.GetById(this.offerDto.ProductId)).Returns((Product)null);

        this.offerService.Insert(this.invalidOfferDto);
    }

    /// <summary>
    /// Tests the offer create not found user.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestOfferCreateNotFoundUser()
    {
        this.productServiceMock.Setup(x => x.GetById(this.offerDto.ProductId)).Returns(this.offer.Product);
        this.userDataServicesMock.Setup(x => x.GetById(this.offerDto.BidderId)).Returns((User)null);

        this.offerService.Insert(this.invalidOfferDto);
    }

    /// <summary>
    /// Tests the offer delete not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<OfferDto>))]
    public void TestOfferDeleteNotFound()
    {
        this.offerDataServicesMock.Setup(x => x.GetById(this.invalidOfferDto.Id)).Returns(this.nullOffer);

        this.offerService.DeleteById(this.invalidOfferDto.Id);
    }

    /// <summary>
    /// Tests the offer delete.
    /// </summary>
    [TestMethod]
    public void TestOfferDelete()
    {
        this.offerDataServicesMock.Setup(x => x.GetById(this.offer.Id)).Returns(this.offer);

        this.offerService.DeleteById(this.offerDto.Id);
    }

    /// <summary>
    /// Tests the offer update.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotImplementedException))]
    public void TestOfferUpdate()
    {
        this.offerService.Update(this.offerDto);
    }
}