// <copyright file="ScoreServiceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestServiceLayer;

using DataMapper;
using DomainModel.Configuration;
using DomainModel.Dto;
using DomainModel.Dto.Validator;
using DomainModel.Entity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using ServiceLayer;
using ServiceLayer.Exception;
using ServiceLayer.ServiceImplementation;

/// <summary>
/// ScoreServiceTest.
/// </summary>
[TestClass]
public class ScoreServiceTest
{
    private Score score;

    private Score nullScore = null;

    private ScoreDto scoreDto;

    private ScoreDto notFoundScoreDto;

    private User reviewerUser;

    private User receiverUser;

    private IScoreService scoreService;

    private Mock<IScoreDataServices> scoreDataServicesMock;

    private Mock<ILogger<ScoreServiceImpl>> loggerMock;

    private MyConfiguration myConfiguration;

    private Mock<IUserDataServices> userDataServicesMock;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        this.receiverUser = new User
        {
            Id = 1,
        };

        this.reviewerUser = new User
        {
            Id = 2,
        };

        this.score = new Score
        {
            Id = 1,
            Receiver = this.receiverUser,
            Reviewer = this.reviewerUser,
            ReceiverId = this.receiverUser.Id,
            ReviewerId = this.reviewerUser.Id,
            Value = 10,
        };

        this.scoreDto = new ScoreDto(this.score);

        this.notFoundScoreDto = new ScoreDto
        {
            Id = int.MaxValue,
            ReceiverId = int.MaxValue,
            ReviewerId = int.MaxValue,
            Value = 10,
        };

        this.scoreDataServicesMock = new Mock<IScoreDataServices>();
        this.loggerMock = new Mock<ILogger<ScoreServiceImpl>>();
        this.myConfiguration = new MyConfiguration
        {
            K = 5,
            P = 5,
            S = 5,
            Z = 5,
        };
        this.userDataServicesMock = new Mock<IUserDataServices>();

        this.scoreService = new ScoreServiceImpl(
            this.scoreDataServicesMock.Object,
            this.loggerMock.Object,
            this.userDataServicesMock.Object,
            new ScoreDtoValidator(),
            Options.Create(this.myConfiguration));
    }

    /// <summary>
    /// Tests the score get all.
    /// </summary>
    [TestMethod]
    public void TestScoreGetAll()
    {
        this.scoreDataServicesMock.Setup(x => x.GetAll()).Returns(new List<Score> { this.score });
        var result = this.scoreService.GetAll();

        CollectionAssert.AreEquivalent(new List<ScoreDto> { this.scoreDto }, result.ToList());
    }

    /// <summary>
    /// Tests the score get by identifier valid.
    /// </summary>
    [TestMethod]
    public void TestScoreGetByIdValid()
    {
        this.scoreDataServicesMock.Setup(x => x.GetById(this.score.Id)).Returns(this.score);
        var result = this.scoreService.GetById(this.scoreDto.Id);

        Assert.AreEqual(this.scoreDto, result);
    }

    /// <summary>
    /// Tests the score get by identifier not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ScoreDto>))]
    public void TestScoreGetByIdNotFound()
    {
        this.scoreDataServicesMock.Setup(x => x.GetById(this.notFoundScoreDto.Id)).Returns(this.nullScore);
        this.scoreService.GetById(this.notFoundScoreDto.Id);
    }

    /// <summary>
    /// Tests the score insert valid.
    /// </summary>
    [TestMethod]
    public void TestScoreInsertValid()
    {
        this.scoreDataServicesMock.Setup(x => x.Insert(It.IsAny<Score>())).Returns(this.score);
        this.userDataServicesMock.Setup(x => x.GetById(this.score.ReceiverId)).Returns(this.score.Receiver);
        this.userDataServicesMock.Setup(x => x.GetById(this.score.ReviewerId)).Returns(this.score.Reviewer);
        var result = this.scoreService.Insert(this.scoreDto);

        Assert.AreEqual(this.scoreDto, result);
    }

    /// <summary>
    /// Tests the score insert not found receiver.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestScoreInsertNotFoundReceiver()
    {
        this.scoreDataServicesMock.Setup(x => x.Insert(It.IsAny<Score>())).Returns(this.score);
        this.userDataServicesMock.Setup(x => x.GetById(this.score.ReceiverId)).Returns((User)null);
        this.userDataServicesMock.Setup(x => x.GetById(this.score.ReviewerId)).Returns(this.score.Reviewer);

        this.scoreService.Insert(this.scoreDto);
    }

    /// <summary>
    /// Tests the score insert not found reviewer.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<UserDto>))]
    public void TestScoreInsertNotFoundReviewer()
    {
        this.scoreDataServicesMock.Setup(x => x.Insert(It.IsAny<Score>())).Returns(this.score);
        this.userDataServicesMock.Setup(x => x.GetById(this.score.ReceiverId)).Returns(this.score.Receiver);
        this.userDataServicesMock.Setup(x => x.GetById(this.score.ReviewerId)).Returns((User)null);

        this.scoreService.Insert(this.scoreDto);
    }

    /// <summary>
    /// Tests the score update invalid.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(FluentValidation.ValidationException))]
    public void TestScoreUpdateInvalid()
    {
        this.scoreService.Update(new ScoreDto());
    }

    /// <summary>
    /// Tests the score update not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ScoreDto>))]
    public void TestScoreUpdateNotFound()
    {
        this.scoreService.Update(this.notFoundScoreDto);
    }

    /// <summary>
    /// Tests the score update valid.
    /// </summary>
    [TestMethod]
    public void TestScoreUpdateValid()
    {
        this.scoreDataServicesMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(this.score);
        this.scoreDataServicesMock.Setup(x => x.Update(It.IsAny<Score>())).Returns(this.score);

        var result = this.scoreService.Update(this.scoreDto);

        Assert.AreEqual(this.scoreDto, result);
    }

    /// <summary>
    /// Tests the score delete not found.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotFoundException<ScoreDto>))]
    public void TestScoreDeleteNotFound()
    {
        this.scoreService.DeleteById(this.notFoundScoreDto.Id);
    }

    /// <summary>
    /// Tests the score delete valid.
    /// </summary>
    [TestMethod]
    public void TestScoreDeleteValid()
    {
        this.scoreDataServicesMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(this.score);
        this.scoreService.DeleteById(this.scoreDto.Id);

        Assert.IsTrue(true);
    }

    /// <summary>
    /// Tests the score get user score default.
    /// </summary>
    [TestMethod]
    public void TestScoreGetUserScoreDefault()
    {
        this.scoreDataServicesMock.Setup(x => x.GetUserScore(It.IsAny<int>())).Returns(-1);
        var result = this.scoreService.GetUserScore(this.scoreDto.ReceiverId);

        Assert.AreEqual(result, this.myConfiguration.S);
    }

    /// <summary>
    /// Tests the score get user score.
    /// </summary>
    [TestMethod]
    public void TestScoreGetUserScore()
    {
        this.scoreDataServicesMock.Setup(x => x.GetUserScore(It.IsAny<int>())).Returns(10);
        var result = this.scoreService.GetUserScore(this.scoreDto.ReceiverId);

        Assert.AreEqual(result, 10);
    }
}