using DataMapper;
using DomainModel.Dto;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

namespace TestServiceLayer;

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
            Owner = new User { Id = 1 }
        };

        offer = new Offer
        {
            Id = 2,
            Product = product,
            Bidder = new User { Id = 2 },
            Price = 200,
            DateTime = DateTime.Now.AddMinutes(1)
        };

        lastOffer = new Offer
        {
            Id = 1,
            Product = product,
            Bidder = new User { Id = 2 },
            Price = 150
        };

        notFoundOfferDto = new OfferDto
        {
            Id = int.MaxValue,
            ProductId = int.MaxValue,
            BidderId = int.MaxValue,
            Price = 200
        };

        invalidOfferDto = new OfferDto
        {
            Id = 1,
            ProductId = 1,
            BidderId = 1,
            Price = int.MaxValue,
            DateTime = DateTime.Now.AddMinutes(1)
        };

        offerDataServicesMock = new Mock<IOfferDataServices>();
        productServiceMock = new Mock<IProductDataServices>();
        userDataServicesMock = new Mock<IUserDataServices>();
        loggerMock = new Mock<ILogger<OfferServiceImpl>>();

        offerDto = new OfferDto(offer);
        lastOfferDto = new OfferDto(lastOffer);

        offerService = new OfferServiceImpl(
            offerDataServicesMock.Object,
            productServiceMock.Object,
            userDataServicesMock.Object,
            loggerMock.Object,
            new OfferDtoValidator());
    }

    [TestMethod]
    public void TestOfferGetAll()
    {
        offerDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Offer> { offer, lastOffer });

        var result = offerService.GetAll();

        CollectionAssert.AreEquivalent(new List<OfferDto> { offerDto, lastOfferDto }, result.ToList());
    }

    [TestMethod]
    public void TestOfferGetAllProductOffers()
    {
        offerDataServicesMock.Setup(x => x.GetAllProductOffers(offerDto.ProductId))
            .Returns(new List<Offer> { offer, lastOffer });

        var result = offerService.GetAllProductOffers(offerDto.ProductId);

        CollectionAssert.AreEquivalent(new List<OfferDto> { offerDto, lastOfferDto }, result.ToList());
    }

    [TestMethod]
    public void TestOfferGetById()
    {
        offerDataServicesMock.Setup(x => x.GetById(offer.Id)).Returns(offer);

        var result = offerService.GetById(offer.Id);

        Assert.AreEqual(offerDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<OfferDto>))]
    public void TestOfferGetByIdNotFound()
    {
        offerDataServicesMock.Setup(x => x.GetById(notFoundOfferDto)).Returns(nullOffer);
        offerService.GetById(offer.Id);
    }

    [TestMethod]
    public void TestOfferGetLastOffer()
    {
        offerDataServicesMock.Setup(x => x.GetLastProductOffer(offerDto.ProductId)).Returns(lastOffer);
        productServiceMock.Setup(x => x.GetById(offerDto.ProductId)).Returns(offer.Product);

        var result = offerService.GetLastProductOffer(offerDto.ProductId);

        Assert.AreEqual(lastOfferDto, result);
    }

    [TestMethod]
    public void TestOfferGetLastOfferNotExist()
    {
        offerDataServicesMock.Setup(x => x.GetLastProductOffer(offerDto.ProductId)).Returns(nullOffer);
        productServiceMock.Setup(x => x.GetById(offerDto.ProductId)).Returns(offer.Product);

        var result = offerService.GetLastProductOffer(offerDto.ProductId);

        Assert.AreEqual(null, result);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestOfferGetLastOfferBotFoundProduct()
    {
        offerDataServicesMock.Setup(x => x.GetLastProductOffer(offerDto.ProductId)).Returns(nullOffer);
        offerService.GetLastProductOffer(offerDto.ProductId);
    }

    [TestMethod]
    public void TestOfferCreate()
    {
        offerDataServicesMock.Setup(x => x.Insert(It.IsAny<Offer>())).Returns(offer);
        productServiceMock.Setup(x => x.GetById(offerDto.ProductId)).Returns(offer.Product);
        userDataServicesMock.Setup(x => x.GetById(offerDto.BidderId)).Returns(offer.Bidder);

        var result = offerService.Insert(offerDto);

        Assert.AreEqual(offerDto, result);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException<OfferDto>))]
    public void TestOfferCreateInvalidOffer()
    {
        productServiceMock.Setup(x => x.GetById(offerDto.ProductId)).Returns(offer.Product);
        userDataServicesMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(offer.Bidder);
        offerDataServicesMock.Setup(x => x.GetLastProductOffer(It.IsAny<int>())).Returns(lastOffer);

        offerService.Insert(invalidOfferDto);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException<OfferDto>))]
    public void TestOfferCreateInvalidOffer2()
    {
        offerDataServicesMock.Setup(x => x.GetLastProductOffer(offerDto.ProductId)).Returns(nullOffer);
        productServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(offer.Product);
        userDataServicesMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(offer.Bidder);

        offerService.Insert(invalidOfferDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ProductDto>))]
    public void TestOfferCreateNotFoundProduct()
    {
        productServiceMock.Setup(x => x.GetById(offerDto.ProductId)).Returns((Product)null);

        offerService.Insert(invalidOfferDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestOfferCreateNotFoundUser()
    {
        productServiceMock.Setup(x => x.GetById(offerDto.ProductId)).Returns(offer.Product);
        userDataServicesMock.Setup(x => x.GetById(offerDto.BidderId)).Returns((User)null);

        offerService.Insert(invalidOfferDto);
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException<OfferDto>))]
    public void TestOfferDeleteNotFound()
    {
        offerDataServicesMock.Setup(x => x.GetById(invalidOfferDto.Id)).Returns(nullOffer);

        offerService.DeleteById(invalidOfferDto.Id);
    }

    [TestMethod]
    public void TestOfferDelete()
    {
        offerDataServicesMock.Setup(x => x.GetById(offer.Id)).Returns(offer);

        offerService.DeleteById(offerDto.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(NotImplementedException))]
    public void TestOfferUpdate()
    {
        offerService.Update(offerDto);
    }
}